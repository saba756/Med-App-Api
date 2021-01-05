using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Helper;
using API.Helper.Enums;
using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class AccountController : BaseAPIController
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        private readonly IAuthRepository _repo;
        private readonly ITokenService _token;
        private readonly IMapper _mapper;
        public AccountController(IHttpContextAccessor httpContextAccessor, IAuthRepository repo , ITokenService token, IMapper mapper
            )
        {
            this.httpContextAccessor = httpContextAccessor;
            _repo = repo;
            _token = token;
            _mapper = mapper;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto  registerDto)
        {

            registerDto.Email = registerDto.Email.ToLower();
            if (await _repo.UserExist(registerDto.Email))
                return BadRequest("user email already exist");
            var userToCreate = _mapper.Map<RegisterDto, User>(registerDto);
            var revoked_by_ip = (this.httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString()); 
            var userToken = new UserToken
            {
                User = userToCreate,
                RefreshToken = _token.GenerateRefreshToken(),
                RefreshTokenExpiryTime= DateTime.UtcNow.AddMonths(1),
                revoked_by_ip = revoked_by_ip,

            };  

            var createdUser = await _repo.Register(userToCreate, registerDto.Password);
            await _token.CreateRefreshToken(userToken);
            var res = _mapper.Map<User, RegisterResponseDtos>(userToCreate);
            res.RefreshToken = _token.GenerateRefreshToken();
            res.AccessToken = _token.CreateToken(userToCreate);
            res.revoked_by_ip = revoked_by_ip;
           
            return Ok(res);
        }
        [Authorize(Policy = "Pharmacy")]
        [HttpGet("address/{id}")]
        public async Task<ActionResult<AddressDto>> GetUserAddress([FromRoute]  int id)
        {
            var user = await _repo.GetById(id);
            var res = _mapper.Map<User, AddressDto>(user);
            return Ok(res);
           
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Content(this.httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString());
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {

            var user = await _repo.Login(loginDto.Email.ToLower(), loginDto.Password);

            if (user == null)
                return Unauthorized();
            var res = new LoginResponseDto
            {
                Email = loginDto.Email,
                AccessToken = _token.CreateToken(user),
                RefreshToken= _token.GenerateRefreshToken(),
                UserType= user.UserType
            };
            return Ok(res);
        }
    }
}
