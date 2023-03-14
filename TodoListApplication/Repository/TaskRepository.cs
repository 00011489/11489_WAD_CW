using TodoListApplication.DatabaseContext;
using TodoListApplication.Repository.Base;
using Task = TodoListApplication.Model.Task;

namespace TodoListApplication.Repository
{
    public class TaskRepository : BaseRepository<Task>
    {
        public TaskRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
