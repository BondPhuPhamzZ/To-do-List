using Microsoft.EntityFrameworkCore;
using To_Do_List.Core.Interfaces;
using To_Do_List.Infrastructure.Data;
using To_Do_List.Infrastructure.Services;

namespace To_Do_List
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 1. Lấy chuỗi kết nối từ appsettings.json
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // 2. Đăng ký AppDbContext dùng SQL Server
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

            // 3. Đki mô hình MVC (Controller + View)
            builder.Services.AddControllersWithViews();

            // Đki DI
            builder.Services.AddScoped<ITodoService, TodoService>();

            var app = builder.Build();

            // 4. Các Middleware cần thiết
            app.UseStaticFiles();
            app.UseRouting();

            //app.MapGet("/", () => "Hello World!");

            app.MapControllerRoute(name: "default", pattern: "{controller=Todo}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
