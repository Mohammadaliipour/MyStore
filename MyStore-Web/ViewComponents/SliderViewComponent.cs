using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyStore_Core.Interfaces;
using MyStore_Web.Models.ViewModels;

namespace MyStore_Web.ViewComponents
{
    public class SliderViewComponent: ViewComponent
    {
        private readonly ISliderServicess _sliderServicess;
        private readonly IMapper _mapper;
        public SliderViewComponent(ISliderServicess sliderServicess, IMapper mapper)
        {
            _sliderServicess = sliderServicess;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var slider=await _sliderServicess.GetfilterSlider();
            var vm=_mapper.Map<List<SliderSimpleviewModel>>(slider);
            return View(vm);
        }
    }
}
