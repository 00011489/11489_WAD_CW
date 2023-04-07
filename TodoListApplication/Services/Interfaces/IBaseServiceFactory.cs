using TodoListApplication.Model;

namespace TodoListApplication.Services.Interfaces
{
    public interface IBaseServiceFactory
    {
        IBaseService<T> Create<T>() where T : BaseEntity;
    }
}
