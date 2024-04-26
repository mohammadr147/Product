using product.Models;

namespace product.Services.IService;

public interface IBaseService
{
    Task<ResponseDto> result(RequestDto requestDto);
}