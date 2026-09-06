using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Runtime.CompilerServices;
using To_Do_List.Core.Interfaces;
using To_Do_List.Core.Models;
using To_Do_List.Infrastructure.Data;

namespace To_Do_List.Infrastructure.Services
{
    public class TodoService : ITodoService
    {
        private readonly AppDbContext _context;
        
        public TodoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ToDoItem>> GetAllTodoAsync()
        {
            return await _context.ToDoItems.OrderByDescending(t => t.CreatedAt).ToListAsync();
        }

        public async Task<ToDoItem?> GetTodoByIdAsync(string id)
        {
            return null;
        }

        public async Task CreateTodoAsync(ToDoItem todo)
        {
            _context.ToDoItems.Add(todo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTodoAsync(ToDoItem todo)
        {
            _context.ToDoItems.Update(todo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTodoAsync(string id)
        {
            var todo = await _context.ToDoItems.FindAsync(id);

            if (todo != null)
            {
                _context.ToDoItems.Remove(todo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
