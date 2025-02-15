using AutoMapper;
using BL.DTOs.CategoryDTOs;
using CORE.Models;

namespace BL.Profiles
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryDTO,Category>().ReverseMap();
            CreateMap<UpdateCategoryDTO,Category>().ReverseMap();
            CreateMap<AdminGetCategoryDTO,Category>().ReverseMap();
            CreateMap<HomeGetCategoryDTO,Category>().ReverseMap();
        }
    }
}
