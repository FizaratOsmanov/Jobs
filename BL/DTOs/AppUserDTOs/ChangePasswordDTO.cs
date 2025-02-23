using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace BL.DTOs.AppUserDTOs
{
    public record ChangePasswordDTO
    {
        [Required(ErrorMessage = "Old password is required.")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "New password is required.")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Repeat new password is required.")]
        [Compare("NewPassword", ErrorMessage = "New passwords do not match.")]
        public string RepeatNewPassword { get; set; }
    }

    public class ChangePasswordDTOValidator : AbstractValidator<ChangePasswordDTO>
    {
        public ChangePasswordDTOValidator()
        {
            RuleFor(x => x.OldPassword)
                .NotEmpty().WithMessage("Old password is required.");

            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("New password is required.")
                .MinimumLength(8).WithMessage("New password must be at least 8 characters long.")
                .Matches("[A-Z]").WithMessage("New password must contain at least one uppercase letter.")
                .Matches("[a-z]").WithMessage("New password must contain at least one lowercase letter.")
                .Matches("[0-9]").WithMessage("New password must contain at least one number.")
                .Matches("[^a-zA-Z0-9]").WithMessage("New password must contain at least one special character (!@#$%^&* etc.).");

            RuleFor(x => x.RepeatNewPassword)
                .NotEmpty().WithMessage("Repeat new password is required.")
                .Equal(x => x.NewPassword).WithMessage("New passwords do not match.");
        }
    }
}
