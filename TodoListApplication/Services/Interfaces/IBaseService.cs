namespace TodoListApplication.Services.Interfaces
{
    public interface IBaseService<T>
    {
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
