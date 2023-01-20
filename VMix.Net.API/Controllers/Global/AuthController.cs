namespace VMix.Net.API.Controllers.Global;

[Route("api/[controller]")]
[AllowAnonymous]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService service;

    public AuthController(IAuthService service)
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
        WatchLogger.Log("Giriş yapan kullanıcı " + result.DisplayName);
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
        WatchLogger.Log(data.FullName + "sisteme kayıt olmuştur.");
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
        WatchLogger.Log(data.UserName + "Token süresi doluğu için yeni Token almıştır.");
        return Ok(result);
    }

    /// <summary>
    /// Kullanıcının mevcut şifresini yenilemek için kullanılır.
    /// </summary>
    /// <param name="data"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("ResetPassword")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto data, CancellationToken cancellationToken)
    {
        var result = await service.ResetPassword(data, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Kullanıcı şifresini hatırlamadığı zaman yenilemek için kullanılır.
    /// </summary>
    /// <param name="data"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("ForgotPassword")]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto data, CancellationToken cancellationToken)
    {
        var result = await service.ForgotPassword(data, cancellationToken);
        return Ok(result);
    }
}
