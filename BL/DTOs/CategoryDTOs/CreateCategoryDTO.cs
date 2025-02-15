using BL.DTOs.JobDTOs;
using BL.DTOs.SliderItemDTOs;
using FluentValidation;

namespace BL.DTOs.CategoryDTOs
{
    public record CreateCategoryDTO
    {
        public string Title { get; set; }
    }

    public class CreateCategoryDTOValidation : AbstractValidator<CreateCategoryDTO>
    {
        public CreateCategoryDTOValidation()
        {
            RuleFor(x => x.Title)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Title cannot be empty!")
                .MinimumLength(3).WithMessage("Title must be at least 3 characters long!")
                .MaximumLength(100).WithMessage("Title cannot exceed 100 characters!");

        }
    }
}
