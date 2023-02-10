namespace VMix.Services.Abstractions;

public interface IConfigNavMenuService
{
    Task<List<NavMenuResultDto>> GetAllNavMenu(string token, CancellationToken cancellationToken);
}
