namespace VMix.Net.API.Controllers.Global;

[ApiController]
[ApiVersion("1.0")]
[Route("api/[controller]")]
[Route("api/v{version:apiVersion}/[controller]")]
public class ConfigNavMenuController : ControllerBase
{
    private readonly IConfigNavMenuService service;

    public ConfigNavMenuController(IConfigNavMenuService service)
    {
        this.service = service;
    }

    /// <summary>
    /// Client side'da menü içeriğini db'den getirme işlemini yerine getirir.
    /// </summary>
    /// <param name="token"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("GetNavMenu/{token}")]
    public async Task<IActionResult> GetAllNavMenu(string token, CancellationToken cancellationToken)
    {
        var result = await service.GetAllNavMenu(token, cancellationToken);
        return Ok(result);
    }
}
