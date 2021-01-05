
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly StoreContext _context;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;
        public TokenService(IHttpContextAccessor httpContextAccessor,IConfiguration config, StoreContext context )
        {
            this.httpContextAccessor = httpContextAccessor;
            _context = context;
            _config = config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:Key"]));
        }

        public async Task<UserToken> CreateNewRefreshToken(UserToken userToken)
        {
            var revoked_by_ip = (this.httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString());
            userToken.revoked_by_ip = revoked_by_ip;
            userToken.RefreshToken = GenerateRefreshToken();
            userToken.RefreshTokenExpiryTime = DateTime.UtcNow.AddMonths(1);
            await _context.UserTokens.AddAsync(userToken);
            await _context.SaveChangesAsync();
            return userToken;
        }

        public async  Task<UserToken> CreateRefreshToken( UserToken user)
        {
           
                //user.RefreshToken = GenerateRefreshToken();
                //user.RefreshTokenExpiryTime = DateTime.UtcNow.AddMonths(1);
                await _context.UserTokens.AddAsync(user);
                await _context.SaveChangesAsync();
           
            return user;
            //return true;
        }

        public string CreateToken(User user)
        {
            var claims = new List<Claim>
                {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("role",user.UserType)
                 //new Claim(JwtRegisteredClaimNames.GivenName, user.DisplayName)
            };
            var cred = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = cred,
                Issuer = _config["Token:Issuer"]

            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}
    