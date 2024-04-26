using System.Net;
using System.Text;
using Newtonsoft.Json;
using product.Models;
using product.Services.IService;

namespace product.Services;

public class BaseService : IBaseService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public BaseService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<ResponseDto> result(RequestDto requestDto)
    {
        HttpClient client = _httpClientFactory.CreateClient("Product");
        HttpRequestMessage message = new();
        message.Headers.Add("Accept", "appliction/json");
        if (requestDto.Data != null)
        {
            message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8,
                "appliction/json");
        }

        message.RequestUri = new Uri(requestDto.url);
        // message.Method = HttpMethod.Get;
        switch (requestDto.httpmethod)
        {
            case 1:
                message.Method = HttpMethod.Get;
                break;
            case 2:
                message.Method = HttpMethod.Post;
                break;
            case 3:
                message.Method = HttpMethod.Put;
                break;
            default:
                message.Method = HttpMethod.Get;
                break;
        }

        HttpResponseMessage? responseMessage = null;
        responseMessage = await client.SendAsync(message);
        switch (responseMessage.StatusCode)
        {
            case HttpStatusCode.Unauthorized:
                return new ResponseDto() { IsSuccess = false, Message = "Unauthorized!", Result = null };
                break;
            case HttpStatusCode.NotFound:
                return new ResponseDto() { IsSuccess = false, Message = "Notfound!", Result = null };
                break;
            case HttpStatusCode.BadRequest:
                return new ResponseDto() { IsSuccess = false, Message = "BadRequest!", Result = null };
                break;
            default:
                var apicontent = await responseMessage.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<ResponseDto>(apicontent);
                return response;
        }
    }
}