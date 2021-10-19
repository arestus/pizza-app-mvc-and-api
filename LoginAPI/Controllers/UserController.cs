using LoginAPI.Models;
using LoginAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoginAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _services;

        public UserController(UserService userService)
        {
            _services = userService;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> Get()
        {

            return _services.GetAll();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _services.Get(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Post([FromBody] UserDTO user)
        {
            var userDTO = _services.Register(user);
            if (userDTO != null)
                return userDTO;
            return BadRequest("Not able too register");


        }

        // PUT api/<UserController>/5
        [Route("Login")]
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Login([FromBody] UserDTO user)
        {
            var userDTO = _services.Login(user);
            if (userDTO != null)
                return Ok(userDTO);
            return BadRequest("Not able too register");

        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
