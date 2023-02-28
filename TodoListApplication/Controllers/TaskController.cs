using Microsoft.AspNetCore.Mvc;
using TodoListApplication.DatabaseContext;
using Task = TodoListApplication.Model.Task;

namespace TodoListApplication.Controllers
{
    public class TaskController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaskController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var users = _context.Tasks.ToList();
            return View(users);
        }

        public IActionResult AddTask(Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
