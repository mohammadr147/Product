using product.Models;
using product.Repository.interfaces;
using product.Services.IService;

namespace product.Repository;

public class CategoryRepository:ICategoryRepository
{
    private readonly IBaseService _baseService;

    public CategoryRepository(IBaseService baseService)
    {
        _baseService = baseService;
    }

    public async Task<ResponseDto> GellAllCategoryForShow()
    {
       var result= await _baseService.result(new RequestDto()
        {
            Data = null,
            url = "http://localhost:5205/Category/all",
            httpmethod = 1,

        });

        return result;
    }

    public async Task<ResponseDto> CreateCategory(CategoriesDto categoriesDto)
    {
        var result= await _baseService.result(new RequestDto()
        {
            Data = categoriesDto,
            url = "http://localhost:5205/Category/category",
            httpmethod = 2,

        });

        return result;
    }
    
}