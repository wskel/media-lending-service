using MediaLendingService.Server.Dto;
using MediaLendingService.Server.Entity;

namespace MediaLendingService.Server.Services;

public interface ILiteraryCategoryService
{
    Task<IEnumerable<LiteraryCategoryDto>> GetCategoriesAsync();

    Task<LiteraryCategoryDto> GetCategoryAsync(int id);

    Task<LiteraryCategoryEntity?> GetCategoryEntityAsync(int id);

    Task<LiteraryCategoryDto> AddCategoryAsync(LiteraryCategoryDto category);

    Task<LiteraryCategoryDto> UpdateCategoryAsync(int id, LiteraryCategoryDto category);

    Task DeleteCategoryAsync(int id);
}