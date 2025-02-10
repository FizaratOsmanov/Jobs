using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BL.DTOs.SliderItemDTOs;
using CORE.Models;

namespace BL.Profiles
{
    public class SliderItemProfile : Profile
    {
        public SliderItemProfile()
        {
            CreateMap<CreateSliderItemDTO, SliderItem>().ReverseMap();
            CreateMap<UpdateSliderItemDTO, SliderItem>().ReverseMap();
            CreateMap<GetSliderItemDTO, SliderItem>().ReverseMap();
            CreateMap<GetSliderItemDTO, UpdateSliderItemDTO>().ReverseMap();
        }
    }
}
