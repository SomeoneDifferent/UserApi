using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using UserApi.Models;

namespace UserApi.Controllers
{
    [Route("api/{MethodName}")]
    public class UserController : ControllerBase
    {
        private readonly UserContext _userContext;

        public UserController(UserContext userContext) => _userContext = userContext;

        [HttpGet("{Id}", Name = "User")]
        public IActionResult Get(int id)
        {
            User user = _userContext.Users.Find(id);

            if (user == null)
                return NotFound(); 

            return Ok(user);
        }
        
        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            if (user == null) 
                return BadRequest();

            User findingUser = _userContext.Users.Find(user.Id);

            if (findingUser != null)
                return BadRequest();

            _userContext.Users.Add(user);
            _userContext.SaveChanges();

            return CreatedAtRoute("User", new { id = user.Id }, user);
        }
    }
}