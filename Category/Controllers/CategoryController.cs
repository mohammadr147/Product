using Category.Model;
using Category.Services.IService;
using Microsoft.AspNetCore.Mvc;

namespace Category.Controllers;

public class CategoryController : Base
{
    private readonly IBaseService _baseService;

    public CategoryController(IBaseService baseService)
    {
        _baseService = baseService;
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _baseService.GetAll();
        return Ok(result);
    }

    [HttpPost("category")]
    public async Task<IActionResult> createcategory(Categories categories)
    {
        var result = await _baseService.create(categories);
        return Ok(result);
    }
}