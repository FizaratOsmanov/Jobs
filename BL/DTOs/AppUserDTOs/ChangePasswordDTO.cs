using System.ComponentModel.DataAnnotations;

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
}
