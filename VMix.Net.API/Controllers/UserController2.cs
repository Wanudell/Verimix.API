namespace VMix.Net.API.Controllers
{
	[ApiController]
	[ApiVersion("1.1")]
	[Route("api/[controller]")]
	[Route("api/v{version:apiVersion}/[controller]")]
	public class UserController2 : ControllerBase
    {
		
        private ILogger<UserController2> logger;
        private readonly VMixDbContext dbContext;
		private readonly IUserService service;

		public UserController2(ILogger<UserController2> logger, VMixDbContext dbContext, IUserService service)
        {
            this.dbContext = dbContext;
			this.service = service;
			this.logger = logger;
        }

		//[HttpPost("AddUsers")]
		//public async Task<IActionResult> AddUsers()
		//{
		//    await userWriteService.AddRangeAsync(new()
		//    {
		//        new(){Id = Guid.NewGuid(), FullName = "Emel Okumuş", Email = "emelokumus@VMix.net", IsActive = true , IsDeleted = false, UserName = "eokumus"},
		//        new(){Id = Guid.NewGuid(), FullName = "ELif Okumuş", Email = "elifokumus@VMix.net", IsActive = true , IsDeleted = false, UserName = "eokumus"},
		//        new(){Id = Guid.NewGuid(), FullName = "Halide Edip Adıvar", Email = "halideedipadivar@VMix.net", IsActive = true , IsDeleted = false, UserName = "h.e.adivar"}
		//    });
		//    dbContext.SaveChanges();
		//    return Ok("Kaydedilmiştir.");
		//}

		[HttpGet("UserList2")]
		public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken)
		{
			var result = await service.GetAllUsers(cancellationToken);
			return Ok(result);
		}

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

		[HttpGet("List")]
        public async Task<IActionResult> GetUsers(CancellationToken cancellationToken)
        {
            await Task.Delay(5000, cancellationToken);
            return Ok("3 kullanıcı var");
        }
    }
}