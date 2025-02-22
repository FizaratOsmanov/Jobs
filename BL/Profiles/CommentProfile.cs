using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BL.DTOs.CommentDTOs;
using CORE.Models;

namespace BL.Profiles
{
    public class CommentProfile:Profile
    {
        public CommentProfile()
        {
            CreateMap<GetCommentDTO,Comment>().ReverseMap();
            CreateMap<CreateCommentDTO,Comment>().ReverseMap(); 
            CreateMap<AdminGetCommentDTO,Comment>().ReverseMap();
        }
    }
}
