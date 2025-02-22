using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.DTOs.CategoryDTOs;
using BL.DTOs.CommentDTOs;
using BL.Exceptions;
using CORE.Models;
namespace BL.Services.Abstractions
{
    public interface ICommentService
    {
        Task HardDeleteCommentAsync(int id);
        Task SoftDeleteCommentAsync(int id);
        Task<ICollection<GetCommentDTO>> GetAllCommentForViewAsync();
        Task<ICollection<AdminGetCommentDTO>> GetAllCommentForAdminAsync();
        Task<Comment> GetCommentByIdForAsync(int id);
        Task CreateCommentAsync(CreateCommentDTO dto, string userId);

    }
}
