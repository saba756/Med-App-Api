using API.Dtos;
using AutoMapper;
using Core.Dtos;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, RegisterResponseDtos>()
                .ForMember(des => des.RefreshToken, opt => opt.Ignore())
                .ForMember(des => des.AccessToken, opt => opt.Ignore())
                .ForMember(des => des.RefreshTokenExpiryTime, opt => opt.Ignore())
                .ForMember(des => des.revoked_by_ip, opt => opt.Ignore());

            CreateMap<RegisterDto, User>();
            CreateMap<TokenDto, User>();
            CreateMap<User, AddressDto>();
        }

    }
}
