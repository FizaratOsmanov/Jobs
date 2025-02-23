using BL.Utilities;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace BL.DTOs.ApplyJobDTOs
{
    public record CreateApplyJobDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Portfolio { get; set; }
        public IFormFile CV { get; set; }
        public string CoverLetter { get; set; }
        public int JobId { get; set; }
    }

    public class CreateApplyJobDTOValidaton : AbstractValidator<CreateApplyJobDTO>
    {
        public CreateApplyJobDTOValidaton()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.Portfolio).Must(url => FileManager.ValidUrl(url)).When(x => !string.IsNullOrWhiteSpace(x.Portfolio))
                .WithMessage("Portfolio must be a valid URL.");

            RuleFor(x => x.CV)
                .NotNull().WithMessage("CV is required.")
                .Must(file => FileManager.ValidCV(file)).WithMessage("CV must be in PDF or DOC format.");

            RuleFor(x => x.CoverLetter)
                .NotEmpty().WithMessage("Cover letter is required.")
                .MinimumLength(50).WithMessage("Cover letter must be at least 50 characters long.");
        }
    }
}
