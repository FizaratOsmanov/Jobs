using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace BL.DTOs.AppUserDTOs
{
    public record LoginDTO
    {
        [Display(Prompt = "Username")]
        public string UserName { get; set; }

        [Display(Prompt = "Password")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

    }

    public class LoginDTOValidation : AbstractValidator<LoginDTO>
    {
        public LoginDTOValidation()
        {
            RuleFor(e => e.UserName)
                .NotEmpty().WithMessage("Username cannot be empty!")
                .MinimumLength(5).WithMessage("Username must be at least 5 symbols long!");

            RuleFor(e => e.Password)
                .NotEmpty().WithMessage("Password cannot be empty!")
                .MinimumLength(4).WithMessage("Password must be at least 4 symbols long!");
        }
    }
}
