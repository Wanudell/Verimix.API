using Verimix.CQRS.CommandRequests;

namespace Verimix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService service;
        private readonly ILogger<UserController> logger;
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
            var result = await service.GetAllUsers(cancellationToken);
            return Ok(result);
        }

        [HttpGet("GetUser/{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var result = await service.GetUserById(id, cancellationToken);
            return Ok(result);
        }

        [HttpPost("NewUser")]
        public async Task<IActionResult> CreateUser([FromBody] NewUserDto data, CancellationToken cancellationToken)
        {
            var result = await service.CreateUser(data, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUserById([FromRoute] Guid id, bool forceDelete, CancellationToken cancellationToken)
        {
            var result = await service.DeleteUserById(id, forceDelete, cancellationToken);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto data, CancellationToken cancellationToken)
        {
            var result = await service.UpdateUser(data, cancellationToken);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUserById([FromRoute] Guid id, UpdateUserByIdDto data, CancellationToken cancellationToken)
        {
            var result = await service.UpdateUserById(id, data, cancellationToken);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}