using CoreChatApiBack.Context;
using CoreChatApiBack.Models;
using CoreChatApiBack.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CoreChatApiBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly AppDBContext _dBContext;
        string message= "";
        public HomeController(AppDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        [HttpGet(Name = "Get")]
        public IActionResult SignUpGet() => Ok();



        [HttpPost]
        public async  Task<IActionResult> SignUpPost([FromBody] SignUpViewModel model)
        {
            var isExist = await _dBContext.Users.FirstOrDefaultAsync(f => f.Email == model.Email) ;

            if (isExist !=null)
            {
                ModelState.AddModelError("Email", "User already registered by this Email");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }
          

            try
            {
                var userData = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email=model.Email                
                };
              await  _dBContext.Users.AddAsync(userData);
               await _dBContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

            return Ok(          
                       new
                       {
                           redirectTo = Url.Action("SignIn", "Home", new {  }),
                           message ,
                           position = ""
                       });
        }


        [HttpGet(Name = "Get")]
        public IActionResult SignInGet() => Ok();    

        
        [HttpPost]
        public async  Task<ActionResult> SignInPost([FromBody] SignInViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var existingData = await _dBContext.Users.FirstOrDefaultAsync(f=>f.Email==model.Email);
                if (existingData !=null)
                {
                   var result= SignInUser(model);
                }


            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Redirect("");

        }

        private object SignInUser(SignInViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
