using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace BL.DTOs.AppUserDTOs
{
    public  record UserPageEditDTO
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IFormFile Photo { get; set; }
        public string Profession { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
    }
    public class UserPageEditDTOValidation : AbstractValidator<UserPageEditDTO>
    {

        public UserPageEditDTOValidation()
        {
            RuleFor(e => e.Id)
               .NotEmpty().WithMessage("Id cannot be null");
            RuleFor(e => e.Email)
                .NotEmpty().WithMessage("Email cannot be empty!")
                .EmailAddress().WithMessage("Email address is wrong!");
            RuleFor(e => e.FirstName)
                .NotEmpty().WithMessage("FirstName cannot be empty!")
                .MinimumLength(2).WithMessage("FirstName must be at least 2 symbols long!");
            RuleFor(e => e.LastName)
                .NotEmpty().WithMessage("LastName cannot be empty!")
                .MinimumLength(1).WithMessage("LastName must be at least 1 symbols long!");
            RuleFor(e => e.Profession)
                .NotEmpty().WithMessage("Profession cannot be empty!");
            RuleFor(e => e.Address)
                .NotEmpty().WithMessage("Address cannot be empty!");
            RuleFor(e => e.Country)
               .NotEmpty().WithMessage("Country cannot be empty!");
            RuleFor(e => e.PhoneNumber)
               .NotEmpty().WithMessage("PhoneNumber cannot be empty!");
        }
    }
}
