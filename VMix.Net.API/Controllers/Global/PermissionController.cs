namespace VMix.Net.API.Controllers.Global;

[Authorize]
[ApiController]
[Route("api/[controller]")]

public class PermissionController : ControllerBase
{
    private readonly IPermissionService service;

    public PermissionController(IPermissionService service)
    {
        this.service = service;
    }

    [HttpPost("CheckPermission")]
    public async Task<IActionResult> CheckPermission([FromBody] CheckPermissionDto data, CancellationToken cancellationToken) //Dictionary<string, object> obj
    {
        var result = await service.CheckPermission(data, cancellationToken);
        return Ok(result);
    }
}
