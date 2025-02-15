using BL.DTOs.CategoryDTOs;
using CORE.Models;

namespace BL.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<ICollection<HomeGetCategoryDTO>> GetCategoryHomeItemsAsync();
        Task<ICollection<AdminGetCategoryDTO>> GetCategoryAdminItemsAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task<Category> GetCategoryByIdWithJobAsync(int id);
        Task<UpdateCategoryDTO> GetCategoryByIdForUpdateAsync(int id);
        Task CreateCategoryAsync(CreateCategoryDTO dto);
        Task UpdateCategoryAsync(UpdateCategoryDTO dto);
        Task SoftDeleteCategoryAsync(int id);
        Task HardDeleteCategoryAsync(int id);
    }
}
