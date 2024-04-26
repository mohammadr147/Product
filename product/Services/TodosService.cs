using System.Net;
using Newtonsoft.Json;
using product.Models;
using product.Services.IService;

namespace product.Services;

public class TodosService : ITodosService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public TodosService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<List<TodosDto>> GetAllTodos()
    {
        HttpClient client = _httpClientFactory.CreateClient("todo");
        HttpRequestMessage message = new();
        message.Headers.Add("Accept", "application/json");
        message.RequestUri = new Uri("https://jsonplaceholder.typicode.com/todos");
        message.Method = HttpMethod.Get;
        HttpResponseMessage? responseMessage = null;
        responseMessage = await client.SendAsync(message);
        switch (responseMessage.StatusCode)
        {
            case HttpStatusCode.BadRequest:
                return new List<TodosDto>() { };
                break;
            default:
                var response =await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<TodosDto>>(response);
                return result;
        }
    }
}