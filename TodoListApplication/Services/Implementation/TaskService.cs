using TodoListApplication.DatabaseContext;
using TodoListApplication.Services.Interfaces;
using Task = TodoListApplication.Model.Task;

namespace TodoListApplication.Services.Implementation
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _context;

        public TaskService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task CreateTask(Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return task;
        }

        public Task UpdateTask(Task task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
            return task;
        }

        public void DeleteTask(int taskId)
        {
            var task = _context.Tasks.Find(taskId);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
        }

        public Task GetTaskById(int taskId)
        {
            return _context.Tasks.Find(taskId);
        }
    }
}
