using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreChatApiBack.Context;
using CoreChatApiBack.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreChatApiBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class UserController : ControllerBase
    {
        private readonly AppDBContext _dbContext;
        public UserController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _dbContext.Users.ToList();
            if (result.Count()>0)
            {
                return Ok(result);
            }
            return NotFound();

        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var user = _dbContext.Users.Find(id);

            if (user !=null)
            {
                return Ok(user);
            }
            return NotFound();


        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] User  user)
        {
            var checkingExistance = _dbContext.Users.FirstOrDefault(f => f.Email == user.Email);
            if (checkingExistance !=null)
            {
                ModelState.AddModelError("Email", "User already registered by this email!!");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {

                return BadRequest();
            }

            return Ok();

        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            var checkingExistance = _dbContext.Users.FirstOrDefault(f => f.Email == user.Email && f.Id !=id);
            if (checkingExistance != null)
            {
                ModelState.AddModelError("Email", "User already registered by this email!!");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                _dbContext.Users.Update(user);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {

                return BadRequest();
            }

            return Ok();

        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _dbContext.Users.FirstOrDefault(f => f.Id == id);
            if (result !=null)
            {
                try
                {
                    _dbContext.Users.Remove(result);
                    _dbContext.SaveChanges();
                }
                catch (Exception)
                {

                    return BadRequest();
                }

                return NoContent();
               
            }

            return NotFound();
        }
    }
}
