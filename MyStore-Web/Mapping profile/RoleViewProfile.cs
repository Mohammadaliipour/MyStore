using Microsoft.VisualStudio.Services.Profile;
using AutoMapper;
using MyStore_Core.DTO;
using MyStore_Web.Models.ViewModels;
using MyStore_Core.DTO.Role;
using MyStore_Web.Models.ViewModels.Role;


namespace MyStore_Web.Mapping_profile
{
    public class RoleViewProfile:AutoMapper.Profile
    {

        public RoleViewProfile()
        {
            CreateMap<RoleDto,RoleviewModel>().ReverseMap();
            CreateMap<RoleEditDto, RoleEditViewModel>().ReverseMap();
            CreateMap<RoleCreatedto, RoleCreateDto>().ReverseMap();
        }
    }
}
