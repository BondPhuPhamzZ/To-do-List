using To_Do_List.Core.Models;

namespace To_Do_List.Core.Interfaces
{
    public interface ITodoService
    {
        Task<IEnumerable<ToDoItem>> GetAllTodoAsync();
        Task<ToDoItem?> GetTodoByIdAsync(string id);
        Task CreateTodoAsync(ToDoItem todo);
        Task UpdateTodoAsync(ToDoItem todo);
        Task DeleteTodoAsync(string id);
    }
}
