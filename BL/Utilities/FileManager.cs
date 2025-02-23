using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;

namespace BL.Utilities
{
    public static class FileManager
    {
        public static async Task<string> SaveAsync(this IFormFile file, string folder)
        {
            string uploadPath = Path.Combine(Path.GetFullPath("wwwroot"), "Uploads", folder);

            if (!Directory.Exists(uploadPath)) Directory.CreateDirectory(uploadPath);

            string filename = Guid.NewGuid().ToString() + file.FileName;

            using (FileStream fs = new(Path.Combine(uploadPath, filename), FileMode.Create))
            {
                await file.CopyToAsync(fs);
            }

            return filename;
        }

        public static bool CheckType(this IFormFile file, string requiredType) => file.ContentType.Contains(requiredType);

        public static bool IsValidImageType(this IFormFile file)
        {
            string[] validTypes = { "image/jpeg", "image/png", "image/jpg", "image/webp", "image/bmp", "image/gif" };
            return validTypes.Contains(file.ContentType);
        }

        public static bool ValidUrl(string? url)
        {
            if (string.IsNullOrWhiteSpace(url)) return false;
            var urlPattern = @"^(http|https)://([\w-]+(\.[\w-]+)+)([/#?]?.*)?$";
            return Regex.IsMatch(url, urlPattern, RegexOptions.IgnoreCase);
        }

        public static bool ValidCV(IFormFile? file)
        {
            if (file == null) return false;
            var allowedExtensions = new[] { ".pdf", ".doc", ".docx" };
            var fileExtension = Path.GetExtension(file.FileName)?.ToLower();
            return allowedExtensions.Contains(fileExtension);
        }
    }
}
