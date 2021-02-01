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
    public class HomeController : Controller
    {
        private readonly AppDBContext _dbContext;        
        public HomeController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result= await _dbContext.Users.ToListAsync();
            return Ok(result);
        }

        
    }
}
