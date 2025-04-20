using BL.DTOs.CommentDTOs;
using CORE.Models;
namespace BL.Services.Abstractions
{
    public interface ICommentService
    {
        Task HardDeleteCommentAsync(int id);
        Task SoftDeleteCommentAsync(int id);
        Task<ICollection<GetCommentDTO>> GetAllCommentForViewAsync();
        Task<ICollection<AdminGetCommentDTO>> GetAllCommentForAdminAsync();
        Task<Comment> GetCommentByIdAsync(int id);
        Task CreateCommentAsync(CreateCommentDTO dto, string userId);

    }
}
