using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BL.DTOs.AppUserDTOs
{
    public record RegisterDTO
    {
        [Display(Prompt = "FirstName")]
        [Required]
        public string FirstName { get; set; }


        [Display(Prompt = "LastName")]
        [Required]
        public string LastName { get; set; }



        [Display(Prompt = "Username")]
        [Required]
        public string Username { get; set; }


        [Display(Prompt = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }



        [Display(Prompt = "Password")]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }



        [Display(Prompt = "ConfirmPassword")]
        [DataType(DataType.Password)]
        [Required]
        public string ConfirmPassword { get; set; }


        [Display(Prompt = "Profession")]
        [Required]
        public string Profession { get; set; }


        [Display(Prompt = "Address")]
        [Required]
        public string Address { get; set; }


        [Display(Prompt = "Country")]
        [Required]
        public string Country { get; set; }



        [Display(Prompt = "PhoneNumber")]
        [Required]
        public string PhoneNumber { get; set; }

        [Display(Prompt = "Add profile photo")]
        public IFormFile Photo { get; set; }     
    }

    public class RegisterDTOValidation : AbstractValidator<RegisterDTO>
    {

        public RegisterDTOValidation()
        {
            RuleFor(e => e.Username)
                .NotEmpty().WithMessage("Username cannot be empty!")
                .MinimumLength(5).WithMessage("Username must be at least 5 symbols long!");
            RuleFor(e => e.Email)
                .NotEmpty().WithMessage("Email cannot be empty!")
                .EmailAddress().WithMessage("Email address is wrong!");
            RuleFor(e => e.Password)
                .NotEmpty().WithMessage("Password cannot be empty!")
                .MinimumLength(4).WithMessage("Password must be at least 4 symbols long!");
            RuleFor(e => e.ConfirmPassword)
                .NotEmpty().WithMessage("Confirm password cannot be empty!")
                .Equal(e => e.Password).WithMessage("Passwords don't match!");
        }
    }
}
