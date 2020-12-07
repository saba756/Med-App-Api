using API.Dtos;
using AutoMapper;
using Core.Dtos;
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
            CreateMap<Core.Entities.Identity.Register, RegisterDto>().ReverseMap();
           
        }

    }
}
