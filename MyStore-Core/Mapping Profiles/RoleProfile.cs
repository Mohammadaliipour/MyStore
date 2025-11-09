using AutoMapper;
using MyStore_Core.DTO.Role;
using MyStore_Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore_Core.Mapping_Profiles
{
    public class RoleProfile:Profile
    {
        public RoleProfile()
        {
            CreateMap<Role,RoleDto>().ReverseMap();
            CreateMap<Role,RoleCreateDto>().ReverseMap();
        }

    }
}
