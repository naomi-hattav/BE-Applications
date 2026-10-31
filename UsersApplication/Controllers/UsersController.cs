using Microsoft.AspNetCore.Mvc;
using UsersApplication.Domain;
using UsersApplication.Services;

namespace UsersApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IList<User>> GetAll() 
        {
            return Ok(_userService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetById(int id)
        {
            var user = _userService.GetById(id);
            return user !=null ? Ok(user) : NotFound();
        }

        [HttpPost]
        public ActionResult<User> Upset(User user)
        {
            var newUser = _userService.Upset(user);
            return CreatedAtAction(nameof(GetById), new { id = newUser.Id}, newUser);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return _userService.Delete(id) ? NoContent() : NotFound();
        }
    }
}
