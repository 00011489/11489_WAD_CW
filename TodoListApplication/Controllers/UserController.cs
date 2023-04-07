using Microsoft.AspNetCore.Mvc;
using TodoListApplication.DatabaseContext;
using TodoListApplication.Model;
using TodoListApplication.Services.Implementation;
using TodoListApplication.Services.Interfaces;

namespace TodoListApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly IBaseService<User> _userService;

        public UserController(IBaseServiceFactory serviceFactory)
        {
            _userService = serviceFactory.Create<User>();
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
}
