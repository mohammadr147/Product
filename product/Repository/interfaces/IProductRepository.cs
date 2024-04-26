using product.Models;

namespace product.Repository.interfaces;

public interface IProductRepository
{
    Task<ResponseDto> CreateProduct(Product product);
    Task<List<Product>> getAllProduct();
}