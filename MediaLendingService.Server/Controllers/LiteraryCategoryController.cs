using MediaLendingService.Server.Dto;
using MediaLendingService.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace MediaLendingService.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LiteraryCategoryController : ControllerBase
{
    private readonly ILiteraryCategoryService _categoryService;

    public LiteraryCategoryController(ILiteraryCategoryService categoryService)
    {
        ArgumentNullException.ThrowIfNull(categoryService);
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LiteraryCategoryDto>>> GetLiteraryCategory()
    {
        var categories = await _categoryService.GetCategoriesAsync();
        return Ok(categories);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<LiteraryCategoryDto>> GetLiteraryCategory(int id)
    {
        var category = await _categoryService.GetCategoryAsync(id);
        return category != null ? Ok(category) : NotFound();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutLiteraryCategory(int id, LiteraryCategoryDto literaryCategory)
    {
        if (id != literaryCategory.Id)
        {
            return BadRequest();
        }

        var updatedCategory = await _categoryService.UpdateCategoryAsync(id, literaryCategory);
        return updatedCategory != null ? Ok(updatedCategory) : NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<LiteraryCategoryDto>> PostLiteraryCategory(
        LiteraryCategoryDto literaryCategory)
    {
        var addedCategory = await _categoryService.AddCategoryAsync(literaryCategory);
        return CreatedAtAction(nameof(GetLiteraryCategory), new { id = addedCategory.Id }, addedCategory);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteLiteraryCategory(int id)
    {
        var result = await _categoryService.DeleteCategoryAsync(id);
        return result ? Ok() : NoContent();
    }
}