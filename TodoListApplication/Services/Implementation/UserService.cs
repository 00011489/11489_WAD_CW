using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Runtime.Intrinsics.X86;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System;
using TodoListApplication.DatabaseContext;
using TodoListApplication.Model;
using TodoListApplication.Services.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace TodoListApplication.Services.Implementation
{
    public class UserService : IBaseService<User>
    {
        public User GetById(int id)
        {
            // implementation to get a user by ID
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

    public class TaskService : IBaseService<Task>
    {
        public Task GetById(int id)
        {
            // implementation to get a task by ID
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
    In this implementation, we have created a common interface called IBaseService that defines the basic operations that a service class should implement.The UserService and TaskService classes implement this interface and are responsible for managing the User and Task entities, respectively. This separation of responsibilities promotes modularity, reduces coupling, and makes it easier to maintain and extend the codebase in the future.Additionally, by using a common interface, we can easily create other service classes that work with different entities using the same basic operations.




    xitoge7069 @pubpng.com
    create controllers
    Sure! Here's an example implementation of the UserController and TaskController in C#, which use the UserService and TaskService respectively to handle HTTP requests.


    csharp
    Copy code
public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            _userService.Add(user);
            return CreatedAtRoute(new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] User user)
        {
            if (user == null || id != user.Id)
            {
                return BadRequest();
            }

            var existingUser = _userService.GetById(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            _userService.Update(user);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingUser = _userService.GetById(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            _userService.Delete(id);

            return NoContent();
        }
    }

    public class TaskController : Controller
    {
        private readonly TaskService _taskService;

        public TaskController(TaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var task = _taskService.GetById(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Task task)
        {
            if (task == null)
            {
                return BadRequest();
            }
            _taskService.Add(task);
            return CreatedAtRoute(new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Task task)
        {
            if (task == null || id != task.Id)
            {
                return BadRequest();
            }

            var existingTask = _taskService.GetById(id);
            if (existingTask == null)
            {
                return NotFound();
            }

            _taskService.Update(task);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingTask = _taskService.GetById(id);
            if (existingTask == null)
            {
                return NotFound();
            }
            _taskService.Delete(id);
            return NoContent();
        }
    }
}
