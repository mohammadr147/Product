using Category.Model;

namespace Category.Services.IService;

public interface IBaseService
{
    Task<ResponseDto> GetAll();
    Task<ResponseDto> create(Categories categories);
}