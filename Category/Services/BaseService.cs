using Category.Data;
using Category.Model;
using Category.Services.IService;

namespace Category.Services;

public class BaseService : IBaseService
{
    private readonly MyContext _myContext;
    private ResponseDto _responseDto;

    public BaseService(MyContext myContext)
    {
        _myContext = myContext;
        _responseDto = new ResponseDto();
    }

    public async Task<ResponseDto> GetAll()
    {
        try
        {
            List<Categories> categories = new();
            categories = _myContext.Categories.ToList();
            _responseDto.IsSuccess = true;
            _responseDto.Result = categories;
        }
        catch (Exception e)
        {
            _responseDto.IsSuccess = false;
            _responseDto.Message = e.Message;
        }

        return _responseDto;
    }

    public async Task<ResponseDto> create(Categories categories)
    {
        try
        {
            _myContext.Add(categories);
            await _myContext.SaveChangesAsync();
            _responseDto.IsSuccess = true;
            _responseDto.Result = categories;
        }
        catch (Exception e)
        {
            _responseDto.IsSuccess = false;
            _responseDto.Message = e.Message;
        }

        return _responseDto;
    }
}