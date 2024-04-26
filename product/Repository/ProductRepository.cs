using product.Data;
using product.Models;
using product.Repository.interfaces;

namespace product.Repository;

public class ProductRepository:IProductRepository
{
    private readonly ProductContext _productContext;

    public ProductRepository(ProductContext productContext)
    {
        _productContext = productContext;
    }

    public async Task<ResponseDto> CreateProduct(Product product)
    {
        try
        {
            var result = _productContext.product.Add(product);
            await _productContext.SaveChangesAsync();
            return new ResponseDto()
            {
                IsSuccess = true,
                Message = null,
                Result = product,
            };
        }
        catch (Exception e)
        {
            return new ResponseDto()
            {
                IsSuccess = false,
                Message = e.Message,
                Result = null,
            };
        }
    }

    public async Task<List<Product>> getAllProduct()
    {
        var result = _productContext.product.ToList();
        return result;
    }
}