using product.Models;

namespace product.Services.IService;

public interface ITodosService
{
    Task<List<TodosDto>> GetAllTodos();
}