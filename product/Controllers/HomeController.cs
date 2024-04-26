using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using product.Models;
using product.Repository.interfaces;

namespace product.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ICategoryRepository _categoryRepository;

    public HomeController(ILogger<HomeController> logger, ICategoryRepository categoryRepository)
    {
        _logger = logger;
        _categoryRepository = categoryRepository;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Category()
    {
        var result = await _categoryRepository.GellAllCategoryForShow();
        if (result.IsSuccess == true)
        {
            var categories = JsonConvert.DeserializeObject<List<CategoriesDto>>(Convert.ToString(result.Result));
            return View(categories);
        }

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}