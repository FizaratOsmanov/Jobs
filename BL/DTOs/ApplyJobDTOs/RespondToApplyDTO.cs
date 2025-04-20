using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace BL.DTOs.ApplyJobDTOs
{
    public  record RespondToApplyDTO
    {
        public int ApplyId { get; set; }
        public string ApplyName { get; set; }
        public string ApplyEmail { get; set; }

        [Required(ErrorMessage = "Response is required.")]
        [StringLength(1000, ErrorMessage = "Response should not exceed 1000 characters.")]
        public string Response { get; set; }

    }

    public class RespondToApplyDTOValidaton : AbstractValidator<RespondToApplyDTO>
    {
        public RespondToApplyDTOValidaton()
        {
            RuleFor(x => x.ApplyName)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(x => x.ApplyEmail)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

        }
    }
}
