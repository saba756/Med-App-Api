using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using API.Extensions;
using AutoMapper;
using Core.Dtos;
using Core.Entities.Identity;
using Core.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController : BaseAPIController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            ITokenService tokenService,
             IMapper mapper
           )
        {
            _tokenService = tokenService;
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;

        }
       
        [HttpGet("address")]
        public async Task<ActionResult<AddressDto>> GetUserAddress()
        {
            var user = await _userManager.
                FindUserByClaimPrincipalWithRegisterAsync(HttpContext.User);

            return new AddressDto
            {
                Address = user.Register.Address,
                City = user.Register.City,
                ZipCode = user.Register.ZipCode,
                FirstName = user.Register.FirstName,
                LastName = user.Register.LastName,
                PhoneNo = user.Register.PhoneNo
            };
                

        }
        [HttpGet("emailexists")]
        public async Task<ActionResult<bool>> CheckEmailExistAsync([FromQuery] string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }
        [ProducesResponseType(200)]
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
                return Unauthorized(new ApiResponse(401));
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded) return Unauthorized(new ApiResponse(401));
         
            var res = new UserDto
            {
                Token = _tokenService.CreateToken(user),
                RefreshToken = _tokenService.GenerateRefreshToken(),
                Displayname = user.DisplayName,
                Email = user.Email
            };
            return  Ok(res);
        }        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (CheckEmailExistAsync(registerDto.Email).Result.Value)
            {
                return new BadRequestObjectResult(new ApiValidationErrorResponse
                {
                    Errors = new[] { "Email address is in use" }
                });
            }
            var register = new RegisterDto
            {
                City = registerDto.City,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Address = registerDto.Address,
                PhoneNo = registerDto.PhoneNo,
                ZipCode = registerDto.ZipCode
            };

            var user = new AppUser
            {
                DisplayName = registerDto.DisplayName,
                Register = _mapper.Map<RegisterDto, Register>(register),
                Email = registerDto.Email,
                UserName = registerDto.Email
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded) return BadRequest(new ApiResponse(400));
            return new UserDto
            {
                Token = _tokenService.CreateToken(user),
                RefreshToken = _tokenService.GenerateRefreshToken(),
                Displayname = user.DisplayName,
                Email = user.Email
            };
        }





    }
}
