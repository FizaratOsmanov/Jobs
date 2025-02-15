using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BL.DTOs.CategoryDTOs;
using BL.DTOs.JobDTOs;
using CORE.Models;

namespace BL.Profiles
{
    public class JobProfile:Profile
    {
        public JobProfile()
        {
            CreateMap<AdminGetJobDTO,Job>().ReverseMap();
            CreateMap<CreateJobDTO,Job>().ReverseMap();
            CreateMap<UpdateJobDTO,Job>().ReverseMap();
            CreateMap<JobListDTO,Job>().ReverseMap();
            CreateMap<JobDetailDTO,Job>().ReverseMap();
        }
    }
}
