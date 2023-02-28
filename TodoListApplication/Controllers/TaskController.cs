using Microsoft.AspNetCore.Mvc;
using TodoListApplication.DatabaseContext;
using TodoListApplication.Services.Interfaces;
using Task = TodoListApplication.Model.Task;

namespace TodoListApplication.Controllers
{
    public class TaskService : IBaseService<Task>
    {
        public Task GetById(int id)
        {
            return null;
        }

        public void Add(Task task)
        {
            // implementation to add a new task
        }

        public void Update(Task task)
        {
            // implementation to update a task
        }

        public void Delete(int id)
        {
            // implementation to delete a task by ID
        }
    }
}
