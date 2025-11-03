using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyStore_Core.DTO;
using MyStore_Core.Interfaces;
using MyStore_Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore_Core.Servicess
{
    public class SliderServicess:ISliderServicess
    {
        private readonly MyStoreDbContext _dbcontext;
        private readonly IMapper _mapper;
        public SliderServicess(MyStoreDbContext dbcontext, IMapper mappe)
        {
            _dbcontext = dbcontext;
            _mapper = mappe;
        }

        public async Task<List<SliderDto>> GettAllSlider() 
        {
            var slider = await _dbcontext.Sliders.ToListAsync();
            if (slider == null)
                return null;
            return _mapper.Map<List<SliderDto>>(slider);
        
        }


        public async Task <SliderDto> GetSliderDto(int id) 
        {

            var slider =await _dbcontext.Sliders.FirstOrDefaultAsync(p=>p.SliderId == id);
            if (slider == null)
                return null;

            return _mapper.Map<SliderDto>(slider);

        
        
        }

        public Task CreateSlider(SliderEditDto dto)
        {
            throw new NotImplementedException();
        }

        public Task EditSlider(SliderEditDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
