using Microsoft.EntityFrameworkCore;
using To_Do_List.Core.Models;

namespace To_Do_List.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
