using BL.Utilities;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace BL.DTOs.SliderItemDTOs;

public class CreateSliderItemDTO
{
    public IFormFile Image { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }
}

public class CreateSliderItemDTOValidation : AbstractValidator<CreateSliderItemDTO>
{
    public CreateSliderItemDTOValidation()
    {
        RuleFor(x => x.Image)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("Image cannot be null!")
            .Must(x => x.Length <= 10 * 1024 * 1024).WithMessage("File size must be less than 10 MB!")
            .Must(x => x.CheckType("image")).WithMessage("File must be image!")
            .Must(x => x.IsValidImageType()).WithMessage("File must be in JPG or PNG format!");


        RuleFor(x => x.Title)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Title cannot be empty!")
            .MinimumLength(3).WithMessage("Title must be at least 3 characters long!")
            .MaximumLength(100).WithMessage("Title cannot exceed 100 characters!");


        RuleFor(x => x.Description)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Description cannot be empty!")
            .MinimumLength(10).WithMessage("Description must be at least 10 characters long!")
            .MaximumLength(500).WithMessage("Description cannot exceed 500 characters!");
    }
}
