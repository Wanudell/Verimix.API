namespace VMix.Net.API.Controllers.Global;

[Authorize]
[ApiController]
[ApiVersion("1.0")]
[Route("api/[controller]")]
[Route("api/v{version:apiVersion}/[controller]")]
public class RoleController : ControllerBase
{
    private readonly IRoleService service;

    public RoleController(IRoleService service)
    {
        this.service = service;
    }

    /// <summary>
    /// Bütün rolleri getirme işlemini yapar.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("RoleList")]
    public async Task<IActionResult> GetAllRoles(CancellationToken cancellationToken)
    {
        var result = await service.GetAllRoles(cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Id numarasına göre rol getirme işlemini yapar.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("GetRole/{id}")]
    public async Task<IActionResult> GetRoleById([FromRoute] int id, CancellationToken cancellationToken)
    {
        var result = await service.GetRoleById(id, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Yeni bir rol oluşturma işlemini yapar.
    /// </summary>
    /// <param name="data"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("CreateRole")]
    public async Task<IActionResult> CreateRole([FromBody] CreateRoleDto data, CancellationToken cancellationToken)
    {
        var result = await service.CreateRole(data, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Bir rolü id numarasına göre silme işlemi yapar.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="forceDelete"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("DeleteRole/{id}")]
    public async Task<IActionResult> DeleteRoleById([FromRoute] int id, bool forceDelete, CancellationToken cancellationToken)
    {
        var result = await service.DeleteRoleById(id, forceDelete, cancellationToken);
        if (result)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    /// <summary>
    /// Mevcut bir rolün güncelleme işlemini yapar.
    /// </summary>
    /// <param name="data"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut("UpdateRole")]
    public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleDto data, CancellationToken cancellationToken)
    {
        var result = await service.UpdateRole(data, cancellationToken);
        if (result)
        {
            return Ok(result);

        }
        return BadRequest(result);
    }

    /// <summary>
    /// Id numarasına göre mevcut bir rolün güncelleme işlemini yapar.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="data"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut("UpdateRole/{id}")]
    public async Task<IActionResult> UpdateRoleById([FromRoute] int id, UpdateRoleByIdDto data, CancellationToken cancellationToken)
    {
        var result = await service.UpdateRoleById(id, data, cancellationToken);
        if (result)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}
