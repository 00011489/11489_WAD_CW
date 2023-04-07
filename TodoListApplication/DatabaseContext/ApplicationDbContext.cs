using Microsoft.EntityFrameworkCore;
using TodoListApplication.Model;
using Task = TodoListApplication.Model.Task;

namespace TodoListApplication.DatabaseContext
{
    public class ApplicationDbContext: DbContext
    {

        private static ApplicationDbContext instance;

        private ApplicationDbContext() { }

        public static ApplicationDbContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ApplicationDbContext();
                }
                return instance;
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }

        public void SaveChanges()
        {
            // implementation to save changes to the database
        }

    }
}
