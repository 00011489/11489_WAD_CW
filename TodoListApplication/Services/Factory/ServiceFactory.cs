using TodoListApplication.DatabaseContext;
using TodoListApplication.Model;
using TodoListApplication.Services.Implementation;
using TodoListApplication.Services.Interfaces;
using Task = TodoListApplication.Model.Task;

namespace TodoListApplication.Services.Factory
{
    public class ServiceFactory : IBaseServiceFactory
    {
        private readonly ApplicationDbContext _context;

        public ServiceFactory(ApplicationDbContext context)
        {
            _context = context;
        }

        public IBaseService<T> Create<T>() where T : BaseEntity
        {
            if (typeof(T) == typeof(User))
            {
                return new UserService(_context) as IBaseService<T>;
            }
            else if (typeof(T) == typeof(Task))
            {
                return new TaskService(_context) as IBaseService<T>;
            }
            else
            {
                throw new NotSupportedException($"Service for type {typeof(T)} is not supported.");
            }
        }
    }
}
