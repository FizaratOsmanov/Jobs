using AutoMapper;
using BL.DTOs.ApplyJobDTOs;
using CORE.Models;

namespace BL.Profiles
{
    public class ApplyJobProfile:Profile
    {
        public ApplyJobProfile()
        {
            CreateMap<CreateApplyJobDTO,ApplyJob>().ReverseMap();
        }
    }
}
