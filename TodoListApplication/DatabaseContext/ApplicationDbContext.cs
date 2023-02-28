using Microsoft.EntityFrameworkCore;
using TodoListApplication.Model;
using Task = TodoListApplication.Model.Task;

namespace TodoListApplication.DatabaseContext
{
    public class ApplicationDbContext: DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }

    }
}
