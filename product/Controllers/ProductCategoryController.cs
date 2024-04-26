using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using product.Models;
using product.Repository.interfaces;

namespace product.Controllers;

public class ProductCategoryController : Controller
{
    private ICategoryRepository _categoryRepository;
    private readonly IProductRepository _productRepository;

    public ProductCategoryController(ICategoryRepository categoryRepository, IProductRepository productRepository)
    {
        _categoryRepository = categoryRepository;
        _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<IActionResult> CreateProduct()
    {
        var ResponseDto = await _categoryRepository.GellAllCategoryForShow();
        if (ResponseDto.IsSuccess = true)
        {
            var listofCategory =
                JsonConvert.DeserializeObject<List<CategoriesDto>>(Convert.ToString(ResponseDto.Result));
            var result = listofCategory.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            ViewBag.list = result;
            return View();
        }


        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(Product product)
    {
        try
        {
            await _productRepository.CreateProduct(product);
            return RedirectToAction("index", "Home");
        }
        catch (Exception e)
        {
            return View(product);
        }
    }

    public async Task<IActionResult> Products()
    {
        var response=await _productRepository.getAllProduct();
        return View(response);
    }
}