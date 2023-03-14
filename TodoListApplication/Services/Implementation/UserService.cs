using TodoListApplication.DatabaseContext;
using TodoListApplication.Model;
using TodoListApplication.Services.Interfaces;

namespace TodoListApplication.Services.Implementation
{
    public class UserService : IBaseService<User>
    {
        public UserService(ApplicationDbContext context)
        {
            Context=context;
        }

        public ApplicationDbContext Context { get; }

        public User GetById(int id)
        {
            return null;
        }

        public void Add(User user)
        {
            // implementation to add a new user
        }

        public void Update(User user)
        {
            // implementation to update a user
        }

        public void Delete(int id)
        {
            // implementation to delete a user by ID
        }
    }
}
