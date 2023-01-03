using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Verimix.Data.Context;

namespace Verimix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ILogger<UserController> logger;
        private VerimixDbContext dbContext;

        public UserController(ILogger<UserController> logger, VerimixDbContext dbContext)
        {
            this.logger = logger;
            this.dbContext = dbContext;
        }

        [HttpGet("List")]
        public IActionResult GetUsers()
        {
            var result = dbContext.Users.ToList();
            return Ok(result);
        }
    }
}