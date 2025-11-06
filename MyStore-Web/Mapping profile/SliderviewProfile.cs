using AutoMapper;
using MyStore_Core.DTO;
using MyStore_Web.Models.ViewModels;

namespace MyStore_Web.Mapping_profile
{
    public class SliderviewProfile:Profile
    {

        public SliderviewProfile()
        {
            CreateMap<SliderEditViewModel, SliderEditDto>().ReverseMap();
            CreateMap<SliderEditViewModel,SliderDto>().ReverseMap();
            CreateMap<SliderViewModel,SliderDto>().ReverseMap();
            CreateMap<SliderCreateDto,SliderCreateViewModel>().ReverseMap();
        }

    }
}
