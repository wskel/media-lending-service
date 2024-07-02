using MediaLendingService.Server.Data;
using MediaLendingService.Server.Dto;
using MediaLendingService.Server.Entity;
using MediaLendingService.Server.Exceptions.api;
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

    public async Task<LiteraryCategoryDto> GetCategoryAsync(int id)
    {
        var categoryEntity = await _dbContext.LiteraryCategories.FindAsync(id);
        if (categoryEntity == null)
        {
            throw NewNotFound(id);
        }

        return ToModel(categoryEntity);
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

    public async Task<LiteraryCategoryDto> UpdateCategoryAsync(int id, LiteraryCategoryDto category)
    {
        var bodyId = category.Id;
        if (id != bodyId)
        {
            throw new BadRequestException($"Literary category id {id} in path does not match body id {bodyId}");
        }

        var categoryEntity = await _dbContext.LiteraryCategories.FindAsync(id);
        if (categoryEntity == null)
        {
            throw NewNotFound(id);
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
                throw NewNotFound(id);
            }
            else
            {
                throw new ConflictException("Literary category not up-to-date");
            }
        }

        await _dbContext.SaveChangesAsync();
        return ToModel(categoryEntity);
    }

    public async Task DeleteCategoryAsync(int id)
    {
        var categoryEntity = await _dbContext.LiteraryCategories.FindAsync(id);
        if (categoryEntity == null)
        {
            throw new NoOpDeleteException();
        }

        _dbContext.LiteraryCategories.Remove(categoryEntity);
        await _dbContext.SaveChangesAsync();
    }

    private bool LiteraryCategoryExists(int id)
        => _dbContext.LiteraryCategories.Any(e => e.Id == id);

    private static LiteraryCategoryDto ToModel(LiteraryCategoryEntity entity) =>
        new(entity.Id, entity.Name);

    private static LiteraryCategoryEntity ToEntity(LiteraryCategoryDto model) =>
        new(model.Id, model.Name);

    private static NotFoundException NewNotFound(int id) =>
        new NotFoundException($"The literary category with id {id} could not be found");
}