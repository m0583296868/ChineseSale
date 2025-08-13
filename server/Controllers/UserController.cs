using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MSMA.BL;
using MSMA.Models;
using MSMA.Models.DTO;


namespace MSMA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

      
        [HttpGet]
       [Authorize(Roles = "Admin")]
        public async Task< IEnumerable<Users>> Get()
        {
            try {
            return await userService.Get();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        [Authorize(Roles = "Admin")]
        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task< Users> Get(int id)
        {
            try { 
            return await userService.Get(id);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        // POST api/<UserController>
        //register
        [HttpPost("register")]
        public async Task AddUser([FromBody] UsersDTO value)
        {
            try {
          await  userService.Add(value);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        //login
        [HttpPost("login")]
        public async Task< resUser> Login(string userName,string password)
        {
           // logger.LogInformation("user"+userName+"maked login in", DateTime.UtcNow.ToLongTimeString());
            try {
                
            return await userService.Login(userName,password);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        // PUT api/<UserController>/5
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UsersDTO value)
        {
            try { 
            userService.Update(id,value);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        [Authorize(Roles = "Admin")]

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try { 
            userService.Remove(id);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }
    }
}
