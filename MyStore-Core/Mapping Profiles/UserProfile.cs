using AutoMapper;
using MyStore_Core.DTO.User;
using MyStore_Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore_Core.Mapping_Profiles
{
    public class UserProfile:Profile
    {
      public UserProfile() 
        {

        CreateMap<RegisterDto,User>().ReverseMap();
        
        
        }
    }
}
