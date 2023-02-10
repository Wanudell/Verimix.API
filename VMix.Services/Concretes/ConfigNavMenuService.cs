namespace VMix.Services.Concretes;

internal class ConfigNavMenuService : IConfigNavMenuService
{
    private readonly IMediator mediator;

    public ConfigNavMenuService(IMediator mediator)
    {
        this.mediator = mediator;
    }

    public Task<List<NavMenuResultDto>> GetAllNavMenu(string token, CancellationToken cancellationToken)
    {
        return mediator.Send(new GetNavMenuRequest(token), cancellationToken);
    }
}
