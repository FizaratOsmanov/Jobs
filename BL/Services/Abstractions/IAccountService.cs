using BL.DTOs.AppUserDTOs;
using Microsoft.AspNetCore.Http;
namespace BL.Services.Abstractions;

public interface IAccountService
{
    Task LoginAsync(LoginDTO dto);
    Task RegisterAsync(RegisterDTO dto);
    Task LogoutAsync();
    Task<UserPageGetDTO> GetCurrentUserAsync(string userId);
    Task ChangePasswordAsync(string userId, ChangePasswordDTO dto);
    Task<ICollection<AdminGetDTO>> GetAllUsersAsync();
    Task UpdateProfilePhotoAsync(string userId, IFormFile photo);
}
