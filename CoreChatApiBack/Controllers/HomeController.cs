using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreChatApiBack.Context;
using CoreChatApiBack.Models;
using CoreChatApiBack.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult SignUpGet()
        {
            var model = new SignUpViewModel();
            return Ok(model);
        }

        [HttpPost]
        public IActionResult SignUpPost([FromBody] SignUpViewModel model)
        {
            var isExist = _dBContext.Users.FirstOrDefault(f => f.Email == model.Email) ;

            if (isExist !=null)
            {
                ModelState.AddModelError("Email", "User already registered by this Email");
            }
            if (!ModelState.IsValid)
            {
                message= "Fail";

            }

            try
            {
                var userData = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email=model.Email                
                };
                _dBContext.Users.Add(userData);
                _dBContext.SaveChanges();

            }
            catch (Exception ex)
            {

                message= ex.Message.ToString();
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
        public ActionResult SignInGet()
        {
            var model = new SignInViewModel();
            return Ok();
        }

        
        [HttpPost]
        public ActionResult SignInPost([FromBody] SignInViewModel model)
        {
            if (! ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var existingData = _dBContext.Users.FirstOrDefault(f=>f.Email==model.Email);
                if (existingData !=null)
                {
                   var result= SignInUser(model);
                }


            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();

        }

        private object SignInUser(SignInViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
