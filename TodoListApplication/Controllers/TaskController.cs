using Microsoft.AspNetCore.Mvc;
using TodoListApplication.DatabaseContext;
using TodoListApplication.Services.Implementation;
using TodoListApplication.Services.Interfaces;
using Task = TodoListApplication.Model.Task;

namespace TodoListApplication.Controllers
{
    public class TaskController : Controller
    {
        private readonly IBaseService<Task> _taskService;

        public TaskController(IBaseServiceFactory serviceFactory)
        {
            _taskService = serviceFactory.Create<Task>();
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
