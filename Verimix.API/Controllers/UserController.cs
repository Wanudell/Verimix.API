namespace Verimix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService service;
        private ILogger<UserController> logger;
        private readonly VerimixDbContext dbContext;

        public UserController(IUserService service, ILogger<UserController> logger, VerimixDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.service = service;
            this.logger = logger;
        }

        [HttpGet("UserList")]
        public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken)
        {
            var result = await service.GetUsers(cancellationToken);
            return Ok(result);
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetUsers(CancellationToken cancellationToken)
        {
            await Task.Delay(5000, cancellationToken);
            return Ok("3 kullanıcı var");
        }
    }
}