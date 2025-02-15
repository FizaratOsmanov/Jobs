using AutoMapper;
using BL.DTOs.CategoryDTOs;
using BL.Exceptions;
using BL.Services.Abstractions;
using CORE.Models;
using DATA.Repositories.Abstractions;
using DATA.Repositories.Implementations;
namespace BL.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        readonly ICategoryRepository _categoryRepository;
        readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {_categoryRepository = categoryRepository;_mapper = mapper;}

        public async Task CreateCategoryAsync(CreateCategoryDTO dto)
        {
            Category category = _mapper.Map<Category>(dto);
            if (category == null)
            {
                throw new BaseException("Category not found");
            }
            await _categoryRepository.CreateAsync(category);
            await _categoryRepository.SaveChangesAsync();
        }

        public async Task SoftDeleteCategoryAsync(int id)
        {
            Category category = await GetCategoryByIdWithJobAsync(id);            
            if (category.Jobs.Count != 0) throw new BaseException("This category has jobs!");
            _categoryRepository.SoftDelete(category);
            await _categoryRepository.SaveChangesAsync();
        }
        
        public async Task HardDeleteCategoryAsync(int id)
        {
            Category category = await GetCategoryByIdWithJobAsync(id);
            if (category == null)
            {
                throw new BaseException("Category not found");
            }
            if (category.Jobs.Count != 0) throw new BaseException("This category has jobs!");
            _categoryRepository.HardDelete(category);
            await _categoryRepository.SaveChangesAsync();
        }

        public async Task<ICollection<AdminGetCategoryDTO>> GetCategoryAdminItemsAsync()
        {
            ICollection<Category> caterories=await _categoryRepository.GetAllAsync();
            ICollection<AdminGetCategoryDTO> dto=_mapper.Map<ICollection<AdminGetCategoryDTO>>(caterories);
            return dto;
        }

        public async Task<ICollection<HomeGetCategoryDTO>> GetCategoryHomeItemsAsync()
        {
            ICollection<Category> caterories = await _categoryRepository.GetAllAsync("Jobs");
            ICollection<HomeGetCategoryDTO> dto = _mapper.Map<ICollection<HomeGetCategoryDTO>>(caterories);
            return dto;
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            Category? category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                throw new BaseException("Category noy found.");
            }
            return category;
        }

        public async Task<UpdateCategoryDTO> GetCategoryByIdForUpdateAsync(int id)
        {
            Category category = await GetCategoryByIdAsync(id);
            UpdateCategoryDTO dto = _mapper.Map<UpdateCategoryDTO>(category);
            if (dto == null)
            {
                throw new BaseException("Mapping error");
            }
            return dto;
        }

        public async Task<Category> GetCategoryByIdWithJobAsync(int id)
        {
            Category? category = await _categoryRepository.GetByIdAsync(id, "Jobs");
            if (category == null)
            {
                throw new BaseException("Category noy found.");
            }
            return category;
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDTO dto)
        {
            Category oldCategory=await GetCategoryByIdAsync(dto.Id);
            Category category=_mapper.Map<Category>(dto);
            category.CreatedDate=oldCategory.CreatedDate;
            _categoryRepository.Update(category);
            await _categoryRepository.SaveChangesAsync();
        }
    }
}
