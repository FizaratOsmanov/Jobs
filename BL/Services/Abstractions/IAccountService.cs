using BL.DTOs.AppUserDTOs;
namespace BL.Services.Abstractions;

public interface IAccountService
{
    Task LoginAsync(LoginDTO dto);
    Task RegisterAsync(RegisterDTO dto);
    Task LogoutAsync();
    Task<UserPageGetDTO> GetCurrentUserAsync(string userId);
    Task ChangePasswordAsync(string userId, ChangePasswordDTO dto);
    Task EditAsync(UserPageEditDTO dto);
}
