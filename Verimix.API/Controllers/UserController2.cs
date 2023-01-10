using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Verimix.Data.Context;
using Verimix.Data.Entities;
using Verimix.Services.Abstractions;
using Verimix.Services.Concretes;

namespace Verimix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController2 : ControllerBase
    {
        private ILogger<UserController2> logger;
        private readonly VerimixDbContext dbContext;

        public UserController2(ILogger<UserController2> logger, VerimixDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }

        //[HttpPost("AddUsers")]
        //public async Task<IActionResult> AddUsers()
        //{
        //    await userWriteService.AddRangeAsync(new()
        //    {
        //        new(){Id = Guid.NewGuid(), FullName = "Emel Okumuş", Email = "emelokumus@verimix.net", IsActive = true , IsDeleted = false, UserName = "eokumus"},
        //        new(){Id = Guid.NewGuid(), FullName = "ELif Okumuş", Email = "elifokumus@verimix.net", IsActive = true , IsDeleted = false, UserName = "eokumus"},
        //        new(){Id = Guid.NewGuid(), FullName = "Halide Edip Adıvar", Email = "halideedipadivar@verimix.net", IsActive = true , IsDeleted = false, UserName = "h.e.adivar"}
        //    });
        //    dbContext.SaveChanges();
        //    return Ok("Kaydedilmiştir.");
        //}

        //[HttpGet("List")]
        //public async Task<IActionResult> GetAllUsers()
        //{
        //    return Ok(userReadService.GetAll());
        //}

        //[HttpDelete("delete/{id}")]
        //public async Task<IActionResult> RemoveUser([FromRoute] Guid id)
        //{
        //    var result = await userWriteService.RemoveAsync(id);
        //    if (result)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}

        //[HttpPut("update")]
        //public async Task<IActionResult> UpdateUser([FromBody] Guid id)
        //{
        //    var result = userWriteService.UpdateById(id);
        //    if (result)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}
    }
}