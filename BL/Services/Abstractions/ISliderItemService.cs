using BL.DTOs.SliderItemDTOs;

namespace BL.Services.Abstractions;

public interface ISliderItemService
{
    Task<ICollection<GetSliderItemDTO>> GetAllSliderItemAsync();
    Task<GetSliderItemDTO?> GetSliderItemByIdAsync(int id);
    Task CreateSliderItemAsync(CreateSliderItemDTO dto);
    Task UpdateSliderItemAsync(UpdateSliderItemDTO dto);
    Task SoftDeleteSliderItemAsync(int id);
    Task HardDeleteSliderItemAsync(int id);
}
