using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreChatApiBack.Context;
using CoreChatApiBack.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreChatApiBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class UserController : ControllerBase
    {
        private readonly AppDBContext _dbContext;
        public UserController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };

        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(long id)
        {
            var u = _dbContext.Users.Find(id);

            var usr = new User
            {
               
            };

            var chat = new Chat
            {
                
            };
            return "value";


        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
