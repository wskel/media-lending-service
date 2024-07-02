using MediaLendingService.Server.Data;
using MediaLendingService.Server.Dto;
using MediaLendingService.Server.Entity;
using Microsoft.EntityFrameworkCore;

namespace MediaLendingService.Server.Services;

public class LiteraryCategoryService : ILiteraryCategoryService
{
    private readonly ApplicationDbContext _dbContext;

    public LiteraryCategoryService(ApplicationDbContext dbContext)
    {
        ArgumentNullException.ThrowIfNull(dbContext);
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<LiteraryCategoryDto>> GetCategoriesAsync()
    {
        var categories = await _dbContext.LiteraryCategories
            .Select(entity => ToModel(entity))
            .ToListAsync();

        return categories;
    }

    public async Task<LiteraryCategoryDto?> GetCategoryAsync(int id)
    {
        var categoryEntity = await _dbContext.LiteraryCategories.FindAsync(id);
        return categoryEntity != null ? ToModel(categoryEntity) : null;
    }

    public async Task<LiteraryCategoryEntity?> GetCategoryEntityAsync(int id)
    {
        return await _dbContext.LiteraryCategories.FindAsync(id);
    }

    public async Task<LiteraryCategoryDto> AddCategoryAsync(LiteraryCategoryDto category)
    {
        var categoryEntity = ToEntity(category);
        await _dbContext.LiteraryCategories.AddAsync(categoryEntity);
        await _dbContext.SaveChangesAsync();

        return ToModel(categoryEntity);
    }

    public async Task<LiteraryCategoryDto?> UpdateCategoryAsync(int id, LiteraryCategoryDto category)
    {
        var categoryEntity = await _dbContext.LiteraryCategories.FindAsync(id);
        if (categoryEntity == null)
        {
            return null;
        }

        categoryEntity.Name = category.Name;

        _dbContext.LiteraryCategories.Update(categoryEntity);

        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!LiteraryCategoryExists(id))
            {
                return null;
            }
            else
            {
                throw; // TODO
            }
        }

        await _dbContext.SaveChangesAsync();
        return ToModel(categoryEntity);
    }

    public async Task<bool> DeleteCategoryAsync(int id)
    {
        var categoryEntity = await _dbContext.LiteraryCategories.FindAsync(id);
        if (categoryEntity == null)
        {
            return false;
        }

        _dbContext.LiteraryCategories.Remove(categoryEntity);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    private bool LiteraryCategoryExists(int id)
        => _dbContext.LiteraryCategories.Any(e => e.Id == id);

    private static LiteraryCategoryDto ToModel(LiteraryCategoryEntity entity) =>
        new(entity.Id, entity.Name);

    private static LiteraryCategoryEntity ToEntity(LiteraryCategoryDto model) =>
        new(model.Id, model.Name);
}