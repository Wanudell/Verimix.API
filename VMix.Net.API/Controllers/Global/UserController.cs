namespace VMix.Net.API.Controllers.Global
{
    [ApiController]
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService service;

        public UserController(IUserService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Bütün kullanıcıları getirme işlemini yapar.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("UserList")]
        public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken)
        {
            var result = await service.GetAllUsers(cancellationToken);
            var currentUser = await service.GetCurrentUser(Request, cancellationToken);
            WatchLogger.Log(currentUser.UserName + " : listeleme işlemi yapmıştır.");
            return Ok(result);
        }

        /// <summary>
        /// Id numarasına göre kullanıcıyı getirme işlemini yapar.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("GetUser/{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id, CancellationToken cancellationToken)
        {
            var result = await service.GetUserById(id, cancellationToken);
            return Ok(result);
        }


        /// <summary>
        /// Token kullanılarak uygun kullanıcıyı getirme işlemini gerçekleştirir.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("GetUserByToken/{token}")]
        public async Task<IActionResult> GetUserByToken(string token, CancellationToken cancellationToken)
        {
            var result = await service.GetUserByToken(token, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Yeni bir kullanıcı ekleme işlemini yapar.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("NewUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto data, CancellationToken cancellationToken)
        {
            //throw new Exception("Something went wrong"); //hata mevcut olduğunda yazdırılabilecek hata bilgisi.
            //WatchLogger.Log("Trying To Make Some Log"); //İstediğimiz bir logu yazabiliriz.
            var result = await service.CreateUser(data, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Bir kullanıcıyı id numarasına göre silme işlemi yapar.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="forceDelete"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUserById([FromRoute] int id, bool forceDelete, CancellationToken cancellationToken)
        {
            var result = await service.DeleteUserById(id, forceDelete, cancellationToken);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        /// <summary>
        /// Mevcut kullanıcının güncelleme işlemini yapar.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Id numarasına göre kullanıcının güncelleme işlemini yapar.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUserById([FromRoute] int id, UpdateUserByIdDto data, CancellationToken cancellationToken)
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