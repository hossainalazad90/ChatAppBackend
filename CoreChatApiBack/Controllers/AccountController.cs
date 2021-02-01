using AutoMapper;
using CoreChatApiBack.Context;
using CoreChatApiBack.Helpers;
using CoreChatApiBack.Models;
using CoreChatApiBack.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreChatApiBack.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDBContext _dbContext;
        private readonly IMapper _mapper;
        string message = "";
        public AccountController(AppDBContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        [HttpGet(Name = "Get")]
        public IActionResult SignUpGet() => Ok();

        [HttpPost]
        public async Task<IActionResult> SignUpPost([FromBody] SignUpViewModel model)
        {
            var isExist = await _dbContext.Users.FirstOrDefaultAsync(f => f.Email == model.Email);

            if (isExist != null)
            {
                ModelState.AddModelError("Email", "User already registered by this Email");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }


            try
            {
                var userData = _mapper.Map<User>(model);
                await _dbContext.Users.AddAsync(userData);
                await _dbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

            return Ok(
                       new
                       {
                           redirectTo = Url.Action("SignIn", "Home", new { }),
                           message,
                           position = ""
                       });
        }


        [HttpGet(Name = "Get")]
        public IActionResult SignInGet() => Ok();


        [HttpPost]
        public async Task<ActionResult> SignInPost([FromBody] SignInViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var existingData = await _dbContext.Users.FirstOrDefaultAsync(f => f.Email == model.Email);
                if (existingData != null)
                {
                    var result = SignInUser(model);
                }


            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Redirect("Home/Index");

        }

        private string SignInUser(SignInViewModel model)
        {
            var getUser = _dbContext.Users.FirstOrDefaultAsync(f => f.Email == model.Email);
            if (getUser !=null )
            {
                HttpContext.Session.SetComplexData("SessionUser", getUser);
                
            }
            
            return "Success";
        }

        public void SignOut()
        {
            HttpContext.Session.Clear();
        }
    }
}
