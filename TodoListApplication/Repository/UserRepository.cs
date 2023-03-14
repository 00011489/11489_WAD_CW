using TodoListApplication.DatabaseContext;
using TodoListApplication.Model;
using TodoListApplication.Repository.Base;

namespace TodoListApplication.Repository
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
