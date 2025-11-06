using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Services.Licensing;
using MyStore_Core.DTO;
using MyStore_Core.Interfaces;
using MyStore_Core.Utilities;
using MyStore_Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore_Core.Servicess
{
    public class SliderServicess : ISliderServicess
    {
        private readonly MyStoreDbContext _dbcontext;
        private readonly IMapper _mapper;
        private readonly IFileManager _fileManager;
        public SliderServicess(MyStoreDbContext dbcontext, IMapper mappe, IFileManager fileManager)
        {
            _dbcontext = dbcontext;
            _mapper = mappe;
            _fileManager = fileManager;
        }

        public async Task<List<SliderDto>> GettAllSlider()
        {
            var slider = await _dbcontext.Sliders.ToListAsync();
            if (slider == null)
                return null;
            return _mapper.Map<List<SliderDto>>(slider);

        }


        public async Task<SliderDto> GetSliderbyid(int id)
        {

            var slider = await _dbcontext.Sliders.FirstOrDefaultAsync(p => p.SliderId == id);
            if (slider == null)
                return null;

            return _mapper.Map<SliderDto>(slider);



        }

        public async  Task CreateSlider(SliderCreateDto createDto)
        {
           
            var slider=_mapper.Map<Slider>(createDto);
            slider.ImageName=_fileManager.SaveFile(createDto.ImageFile,Directories.SliderImage);
            if (createDto.ImageFile == null)
                slider.ImageName = "";
            await _dbcontext.Sliders.AddAsync(slider);
          await  _dbcontext.SaveChangesAsync();
            
        }
        public async Task EditSlider(SliderEditDto dto)
        {    
           var def = _dbcontext.Sliders.FirstOrDefault(p => p.SliderId == dto.SliderId);
            _mapper.Map(dto,def);
            var oldimage=def.ImageName;        
            if (dto.ImageFile != null)
            def.ImageName = _fileManager.SaveFile(dto.ImageFile, Directories.SliderImage);
            _dbcontext.SaveChanges();
            if (dto.ImageFile != null)
                _fileManager.DeleteFile(oldimage,Directories.SliderImage);
                      
        }

        public async Task DeleteSlider(int id)
        {
            var deletfile=_dbcontext.Sliders.FirstOrDefault(s => s.SliderId == id);
            if (deletfile != null)
            {
                _dbcontext.Remove(deletfile);
                _dbcontext.SaveChanges() ;
            }
        }
    }
}
