using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyStore_Core.DTO;
using MyStore_Core.Interfaces;
using MyStore_Data.Entities;
using MyStore_Web.Models.ViewModels;

namespace MyStore_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SlidersController : Controller
    {

        private readonly ISliderServicess _sliderServicess;
        private readonly IMapper _mapper;

        public SlidersController(ISliderServicess sliderServicess, IMapper mapper)
        {
            _mapper = mapper;
            _sliderServicess = sliderServicess;
        }

        // GET: Admin/Sliders
        public async Task<IActionResult> Index()
        {

            var slierlistDto = await _sliderServicess.GettAllSlider();

            var ListViewModel = slierlistDto.Select(dto => new SliderViewModel
            {
                SliderId = dto.SliderId,
                DiscountTitle = dto.DiscountTitle,
                Title = dto.Title,
                ImageName = dto.ImageName,
                Startdate = dto.StartDate,
                Enddate = dto.EndDate,
                IsActive = dto.IsActive
            }).ToList();
            return View(ListViewModel);
        }

        // GET: Admin/Sliders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var slider = await _sliderServicess.GetSliderbyid((int)id);
            if (slider == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<SliderViewModel>(slider);


            return View(viewModel);
        }

        // GET: Admin/Sliders/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DiscountTitle,Title,ImageFile,Startdate,Enddate,IsActive")] SliderCreateViewModel viewModel)
        {
            var sliders = new SlidereditDto()
            {
                DiscountTitle = viewModel.DiscountTitle,
                ImageFile = viewModel.ImageFile,
                EndDate = viewModel.Enddate,
                IsActive = viewModel.IsActive,
                Title = viewModel.Title,
                StartDate = viewModel.Startdate
            };
            await _sliderServicess.CreateSlider(sliders);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var edit = await _sliderServicess.GetSliderbyid((int)id);
            if (edit == null)
            {
                return NotFound();
            }
            var editview = _mapper.Map<SliderEditViewModel>(edit);
            return View(editview);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SliderId,DiscountTitle,Title,Imagefile ,Startdate,Enddate,IsActive")] SliderEditViewModel slider)
        {
            if (id != slider.SliderId)
            {
                return NotFound();
            }
            var sliderdto = _mapper.Map<SliderEditDto>(slider);
            await _sliderServicess.EditSlider(sliderdto);
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Sliders/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slider = await _sliderServicess.GetSliderbyid(id);
            var view = _mapper.Map<SliderViewModel>(slider);
            return View(view);
        }
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var slider = await _context.Sliders.FindAsync(id);
        //    if (slider != null)
        //    {
        //        _context.Sliders.Remove(slider);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}



        //private bool SliderExists(int id)
        //{
        //    return _context.Sliders.Any(e => e.SliderId == id);
        //    }
        //}
    }
}