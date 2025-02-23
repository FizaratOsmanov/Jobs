using AutoMapper;
using BL.DTOs.AppUserDTOs;
using BL.Exceptions;
using BL.Services.Abstractions;
using CORE.Enums;
using CORE.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{

    public class AccountController : Controller
    {
        private readonly IAccountService _service;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public AccountController(IAccountService service, UserManager<AppUser> userManager,IMapper mapper)
        {
            _service = service;
            _userManager = userManager;
            _mapper = mapper;   
        }

       
        public async Task<IActionResult> Index()
        {
            if (User.Identity is not { IsAuthenticated: true })
                return RedirectToAction("Login");

            var userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return RedirectToAction("Login");
            }
            var userDto = await _service.GetCurrentUserAsync(userId);
            return View(userDto);
        }
        
        public IActionResult Login()
        {
            if (User.Identity is not null && User.Identity.IsAuthenticated)
                return Redirect(User.IsInRole(RoleEnum.Admin.ToString()) ? "/admin" : "/");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDTO dto, string? returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            try
            {
                await _service.LoginAsync(dto);
            }
            catch (BaseException ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return View(dto);
            }
            catch
            {
                ModelState.AddModelError("Error", "Error");
                return View(dto);
            }

            return Redirect(returnUrl ?? (User.IsInRole(RoleEnum.Admin.ToString()) ? "/admin" : "/"));
        }
        public IActionResult Register()
        {
            if (User.Identity is not null && User.Identity.IsAuthenticated)
                return Redirect(User.IsInRole(RoleEnum.Admin.ToString()) ? "/admin" : "/");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                ModelState.AddModelError("Error", string.Join(", ", errors));
                return View(dto);
            }
            if (dto.Password != dto.ConfirmPassword)
            {
                ModelState.AddModelError("Error", "Passwords do not match!");
                return View(dto);
            }
            try
            {
                await _service.RegisterAsync(dto);
            }

            catch (BaseException ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return View(dto);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", $"An unexpected error occurred: {ex.Message}");
                return View(dto);
            }

            return Redirect("/Account/Login");
        }
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _service.LogoutAsync();
                return Redirect("/");
            }
            catch (BaseException ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return BadRequest();
            }
        }


        
        public IActionResult ChangePassword()
        {
            return View(new ChangePasswordDTO());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordDTO dto)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "Invalid data.");
                return View(dto);
            }

            try
            {
                var userId = _userManager.GetUserId(User);
                if (userId == null)
                    return RedirectToAction("Login");

                await _service.ChangePasswordAsync(userId, dto);
                return RedirectToAction("Index");
            }
            catch (BaseException ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return View(dto);
            }
        }


        public async  Task<IActionResult> Edit()
        {
            var userId = _userManager.GetUserId(User);
            if (userId == null)
                return RedirectToAction("Login");
            var user =await  _service.GetCurrentUserAsync(userId);
            var dto = _mapper.Map<UserPageEditDTO>(user);
            dto.Id = userId; 
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserPageEditDTO dto)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "Invalid data.");
                return View(dto);
            }

            try
            {
                await _service.EditAsync(dto);
                return RedirectToAction("Index");
            }
            catch (BaseException ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return View(dto);
            }
        }

    }
}
