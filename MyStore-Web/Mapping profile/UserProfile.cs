using AutoMapper;
using MyStore_Core.DTO.User;
using MyStore_Web.Models.ViewModels.User;

namespace MyStore_Web.Mapping_profile
{
    public class UserProfile:Profile

    {

        public UserProfile()
        {
           CreateMap<RegisterDto,RegisterViewModel>().ReverseMap();     
        }
    }
}
