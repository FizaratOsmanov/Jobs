using AutoMapper;
using BL.DTOs.AppUserDTOs;
using CORE.Models;

namespace BL.Profiles
{
    public  class AccountProfile:Profile
    {
        public AccountProfile()
        {
            CreateMap<LoginDTO ,AppUser>().ReverseMap();
            CreateMap<RegisterDTO ,AppUser>().ReverseMap();
            CreateMap<UserPageGetDTO ,AppUser>().ReverseMap();
            CreateMap<UserPageEditDTO ,AppUser>().ReverseMap();
            CreateMap<ChangePasswordDTO ,AppUser>().ReverseMap();
        }
    }
}
