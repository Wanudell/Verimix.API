namespace VMix.Net.API.Controllers
{
    [Route("api/[controller]")]
	[AllowAnonymous]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{
		private readonly IAuthenticationService service;

		public AuthenticationController(IAuthenticationService service)
		{
			this.service = service;
		}

		/// <summary>
		/// Kullanıcı Login süreçlerini gerçekleştirir.
		/// </summary>
		/// <param name="data"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		[HttpPost("Login")]
		public async Task<IActionResult> LoginUser([FromBody] LoginUserDto data, CancellationToken cancellationToken)
		{
			var result = await service.LoginUser(data, cancellationToken);
			return Ok(result);
		}

		/// <summary>
		/// Yeni bir kullanıcı oluşturma işlemini yapar.
		/// </summary>
		/// <param name="data"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		[HttpPost("Register")]
		public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDto data, CancellationToken cancellationToken)
		{
			//throw new Exception("Something went wrong"); //hata mevcut olduğunda yazdırılabilecek hata bilgisi.
			//WatchLogger.Log("Trying To Make Some Log"); //İstediğimiz bir logu yazabiliriz.
			var result = await service.RegisterUser(data, cancellationToken);
			return Ok(result);
		}

		/// <summary>
		/// Kullanıcı için yeni bir token üretimi işlemini yapar.
		/// </summary>
		/// <param name="data"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		[HttpPost("RefreshToken")]
		public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDto data, CancellationToken cancellationToken)
		{
			var result = await service.RefreshToken(data, cancellationToken);
			return Ok(result);
		}
	}
}
