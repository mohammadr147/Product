using product.Models;

namespace product.Repository.interfaces;

public interface ICategoryRepository
{
    Task<ResponseDto> GellAllCategoryForShow();
    Task<ResponseDto> CreateCategory(CategoriesDto categoriesDto);
}