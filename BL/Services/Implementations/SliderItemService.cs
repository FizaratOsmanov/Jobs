using System.Numerics;
using AutoMapper;
using BL.DTOs.SliderItemDTOs;
using BL.Exceptions;
using BL.Services.Abstractions;
using BL.Utilities;
using CORE.Models;
using DATA.Contexts;
using DATA.Repositories.Abstractions;

namespace BL.Services.Implementations;

public class SliderItemService : ISliderItemService
{

    readonly ISliderItemRepository _repository;
    readonly IMapper _mapper;
    readonly AppDbContext _appDbContext;
    public SliderItemService(ISliderItemRepository repository, AppDbContext appDbContext, IMapper mapper)
    {
        _appDbContext = appDbContext;
        _repository = repository;
        _mapper = mapper;
    }

    public async Task CreateSliderItemAsync(CreateSliderItemDTO dto)
    {
        SliderItem sliderItem = _mapper.Map<SliderItem>(dto);
        if(sliderItem.ImgPath is null) sliderItem.ImgPath = await dto.Image.SaveAsync("SliderItems");
        await _repository.CreateAsync(sliderItem);
        await _repository.SaveChangesAsync();
    }




    public async Task<ICollection<GetSliderItemDTO>> GetAllSliderItemAsync()
    {
        var slider = await _repository.GetAllAsync();
        if (slider == null)
        {
            throw new BaseException("Slider item not found.");
        }
        return _mapper.Map<ICollection<GetSliderItemDTO>>(slider);
    }




    public async Task<GetSliderItemDTO?> GetSliderItemByIdAsync(int id)
    {
        SliderItem? slider = await _repository.GetByIdAsync(id);
        if (slider == null)
        {
            throw new BaseException("Slider item not found.");
        }
        GetSliderItemDTO dto = _mapper.Map<GetSliderItemDTO>(slider);
        return dto;
    }





    public async Task SoftDeleteSliderItemAsync(int id)
    {
        SliderItem? sliderItem= await _repository.GetByIdAsync(id);
        if(sliderItem == null)
        {
            throw new BaseException("Slider item not found.");
        }
        _repository.SoftDelete(sliderItem);
        int result=await  _repository.SaveChangesAsync();
        if(result == 0)
        {
            throw new BaseException("Cannot save to databasse");
        }
    }





    public async Task HardDeleteSliderItemAsync(int id)
    {
        SliderItem? sliderItem = await _repository.GetByIdAsync(id);
        if (sliderItem == null)
        {
            throw new BaseException("Slider item not found.");
        }
        _repository.HardDelete(sliderItem);
        int result = await _repository.SaveChangesAsync();
        if (result == 0)
        {
            throw new BaseException("Cannot save to databasse");
        }
        if(sliderItem.ImgPath is not null) File.Delete(Path.Combine(Path.GetFullPath("wwwroot"), "Uploads", "SliderItems", sliderItem.ImgPath));  
    }







    public async Task UpdateSliderItemAsync(UpdateSliderItemDTO dto)
    {
        var sliderItem = await GetSliderItemByIdAsync(dto.Id);
        if (sliderItem == null) throw new BaseException("Slider item not found");
        var newSliderItem = _mapper.Map<SliderItem>(dto);
        if (newSliderItem == null) throw new BaseException("Mapping failed");
        if (dto.Image != null)
        {
            var oldImagePath = Path.Combine(Path.GetFullPath("wwwroot"), "Uploads", "SliderItems", sliderItem.ImgPath);
            if (File.Exists(oldImagePath))
            {
                File.Delete(oldImagePath);
            }
            string newImageFilename = await dto.Image.SaveAsync("SliderItems");
            newSliderItem.ImgPath = newImageFilename;
        }
        _repository.Update(newSliderItem);
        await _repository.SaveChangesAsync();
    }
}
