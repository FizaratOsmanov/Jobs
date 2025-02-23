using BL.DTOs.CategoryDTOs;
using FluentValidation;

namespace BL.DTOs.CommentDTOs
{
    public record CreateCommentDTO
    {
        public string Message { get; set; }
    }
    public class CreateCommentDTOValidation : AbstractValidator<CreateCommentDTO>
    {
        public CreateCommentDTOValidation()
        {
            RuleFor(x => x.Message)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Message cannot be empty!")          
                .MaximumLength(1000).WithMessage("Message cannot exceed 100 characters!");

        }
    }
}
