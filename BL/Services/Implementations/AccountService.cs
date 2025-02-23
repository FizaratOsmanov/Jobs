using AutoMapper;
using BL.DTOs.AppUserDTOs;
using BL.Exceptions;
using BL.Services.Abstractions;
using BL.Utilities;
using CORE.Enums;
using CORE.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace BL.Services.Implementations
{
    public class AccountService:IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;
        public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }
        public async Task RegisterAsync(RegisterDTO dto)
        {
            if (await _userManager.FindByNameAsync(dto.Username) is not null)
                throw new BaseException("Username or email is already taken.");
            if (await _userManager.FindByEmailAsync(dto.Email) is not null)
                throw new BaseException("Username or email is already taken.");
            AppUser user = _mapper.Map<AppUser>(dto);
            if (user.PhotoPath is null) user.PhotoPath = await dto.Photo.SaveAsync("UserProfiles");
            IdentityResult result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                throw new BaseException("User creation failed: ");
            }
            result = await _userManager.AddToRoleAsync(user, RoleEnum.User.ToString());
            if (!result.Succeeded)
            {
                throw new BaseException("Failed to assign user role");
            }
        }
        public async Task LoginAsync(LoginDTO dto)
        {
            AppUser user = await _userManager.FindByNameAsync(dto.UserName) ?? throw new BaseException("Error");
            SignInResult result = await _signInManager.PasswordSignInAsync(user, dto.Password, dto.RememberMe, true);
            if (!result.Succeeded)
            {
                throw new BaseException();
            }
        }
        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
        public async Task<UserPageGetDTO> GetCurrentUserAsync(string userId)
        {

            if (string.IsNullOrEmpty(userId))
            {
                throw new BaseException("User ID is invalid or null");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new BaseException("User not found");
            }

            return _mapper.Map<UserPageGetDTO>(user);
        }
        public async Task ChangePasswordAsync(string userId, ChangePasswordDTO dto)
        {
            var user = await _userManager.FindByIdAsync(userId) ?? throw new BaseException("User not found");

            if (dto.NewPassword != dto.RepeatNewPassword)
                throw new BaseException("New passwords do not match.");

            var result = await _userManager.ChangePasswordAsync(user, dto.OldPassword, dto.NewPassword);
            if (!result.Succeeded)
                throw new BaseException("Password change failed ");
        }
        public async Task EditAsync(UserPageEditDTO dto)
        {
            var user = await _userManager.FindByIdAsync(dto.Id) ?? throw new BaseException("User not found");

            UserPageEditDTO editDto=_mapper.Map<UserPageEditDTO>(user);

            if (dto.Photo != null)
            {
                user.PhotoPath = await dto.Photo.SaveAsync("UserProfiles");
            }

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                throw new BaseException("Profile update failed ");
            }
        }

        public async Task<ICollection<AdminGetDTO>> GetAllUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            return _mapper.Map<ICollection<AdminGetDTO>>(users);
        }

    }
}
