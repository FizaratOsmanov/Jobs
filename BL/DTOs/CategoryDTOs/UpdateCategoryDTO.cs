using FluentValidation;

namespace BL.DTOs.CategoryDTOs
{
    public record UpdateCategoryDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }        
    }

    public class UpdateCategoryDTOValidation : AbstractValidator<UpdateCategoryDTO>
    {
        public UpdateCategoryDTOValidation()
        {
            RuleFor(e => e.Id)
                .NotEmpty().WithMessage("Id cannot be null")
                .GreaterThan(0).WithMessage("Id must be greater than zero!");


            RuleFor(x => x.Title)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Title cannot be empty!")
                .MinimumLength(3).WithMessage("Title must be at least 3 characters long!")
                .MaximumLength(100).WithMessage("Title cannot exceed 100 characters!");

        }
    }
}
