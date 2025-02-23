using BL.Utilities;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace BL.DTOs.JobDTOs
{
    public record UpdateJobDTO
    {
        public int Id { get; set; }
        public IFormFile CompanyIcon { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public decimal MinSalary { get; set; }
        public decimal MaxSalary { get; set; }
        public string Description { get; set; }
        public string Responsiblity { get; set; }

        public int VacancyCount { get; set; }
        public string Qualification { get; set; }
        public DateTime DateLine { get; set; }
        public string CompanyDetail { get; set; }
        public int CategoryId { get; set; }
    }
    public class UpdateJobDTOValidaton : AbstractValidator<UpdateJobDTO>
    {
        public UpdateJobDTOValidaton()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Job ID must be greater than 0.");

            RuleFor(x => x.CompanyIcon)
                .Must(x => x.IsValidImageType()).When(x => x.CompanyIcon != null)
                .WithMessage("Company icon must be in image format (jpeg, png, jpg).");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");

            RuleFor(x => x.Location)
                .NotEmpty().WithMessage("Location is required.")
                .MaximumLength(200).WithMessage("Location cannot exceed 200 characters.");

            RuleFor(x => x.MinSalary)
                .GreaterThanOrEqualTo(0).WithMessage("Minimum salary cannot be less than 0.");

            RuleFor(x => x.MaxSalary)
                .GreaterThanOrEqualTo(x => x.MinSalary).WithMessage("Maximum salary cannot be less than minimum salary.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.");

            RuleFor(x => x.Responsiblity)
                .NotEmpty().WithMessage("Responsibility is required.");

            RuleFor(x => x.Qualification)
                .NotEmpty().WithMessage("Qualification is required.");

            RuleFor(x => x.DateLine)
                .GreaterThan(DateTime.Now).WithMessage("Deadline cannot be a past date.");

            RuleFor(x => x.VacancyCount)
                .GreaterThan(0).WithMessage("Vacancy count must be greater than 0.");

            RuleFor(x => x.CompanyDetail)
                .NotEmpty().WithMessage("Company details are required.");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("Category ID must be greater than 0.");
        }
    }
}
