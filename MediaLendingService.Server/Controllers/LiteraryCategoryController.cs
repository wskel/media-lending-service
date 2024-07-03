using MediaLendingService.Server.Dto;
using MediaLendingService.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediaLendingService.Server.Controllers;

[Authorize(Roles = nameof(UserRoleDto.Librarian))]
[Route("api/v0/[controller]")]
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
        return Ok(await _categoryService.GetCategoriesAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<LiteraryCategoryDto>> GetLiteraryCategory(int id)
    {
        return Ok(await _categoryService.GetCategoryAsync(id));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutLiteraryCategory(int id, LiteraryCategoryDto literaryCategory)
    {
        return Ok(await _categoryService.UpdateCategoryAsync(id, literaryCategory));
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
        await _categoryService.DeleteCategoryAsync(id);
        return Ok();
    }
}