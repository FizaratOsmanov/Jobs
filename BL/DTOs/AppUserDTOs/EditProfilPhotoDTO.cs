using Microsoft.AspNetCore.Http;

namespace BL.DTOs.AppUserDTOs
{
    public record EditProfilPhotoDTO
    {
        public string Id { get; set; }
        public IFormFile Photo { get; set; }
    }
}
