using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using To_Do_List.Core.Interfaces;
using To_Do_List.Core.Models;
using To_Do_List.Web.ViewModels;

namespace To_Do_List.Web.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        public async Task<IActionResult> Index()
        {
            var todos = await _todoService.GetAllTodoAsync();

            var viewModels = todos.Select(t => new TodoIndexViewModel
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                DueDate = t.DueAt,
                IsCompleted = t.IsCompleted
            }).ToList();

            return View(viewModels);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ToDoCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var todo = new ToDoItem()
            {
                Id = Guid.NewGuid().ToString(),
                Title = model.Title,
                Description = model.Description,
                DueAt = (DateTime)model.DueDate,
                CreatedAt = DateTime.Now
            };

            await _todoService.CreateTodoAsync(todo);
            TempData["Success"] = "Thêm công việc thành công!";
            return RedirectToAction(nameof(Index));

        }

    }
}
