using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TokenController : BaseAPIController
    {
        private readonly StoreContext _storeContext;

        readonly ITokenService _tokenService;
        private readonly IAuthRepository _repo;
        private readonly IMapper _mapper;
        public TokenController(StoreContext storeContext, ITokenService tokenService, IAuthRepository repo , IMapper mapper)
        {
            _repo = repo;
            _storeContext = storeContext;
            _tokenService = tokenService;
            _mapper = mapper;

        }
        [HttpPost("refresh")]
        public IActionResult Refresh(TokenDto tokenDto)
        {
            if(tokenDto.AccessToken == null  || tokenDto.RefreshToken == null)
            {
                return BadRequest("Invalid client request");
            }

           var userToCreate = _mapper.Map<User>(tokenDto);
            tokenDto.AccessToken = _tokenService.CreateToken(userToCreate);
            tokenDto.RefreshToken = _tokenService.GenerateRefreshToken();
            var userToken = new UserToken
            {
                User = userToCreate,
                RefreshToken = tokenDto.RefreshToken
            };
            _tokenService.RevokeNewRefreshToken(userToken);
           
            if (userToCreate == null || userToken.RefreshToken == null || userToken.RefreshTokenExpiryTime <= DateTime.Now)
            {
                return BadRequest("Invalid client request");
            }
            return Ok(userToken);
        }
        }
}
