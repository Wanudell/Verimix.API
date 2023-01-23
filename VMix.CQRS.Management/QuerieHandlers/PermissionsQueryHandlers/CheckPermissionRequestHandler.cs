namespace VMix.CQRS.Management.QuerieHandlers.PermissionsQueryHandlers;

public class CheckPermissionRequestHandler : IRequestHandler<CheckPermissionRequest, bool>
{
    private readonly IUnitOfWork unitOfWork;

    public CheckPermissionRequestHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(CheckPermissionRequest request, CancellationToken cancellationToken)
    {
        var currentUser = unitOfWork.GetRepository<AuthUser>().Get(x => x.token == request.Data.Token, cancellationToken);
        var permissions = unitOfWork.GetRepository<AuthPermission>().GetAll(x => x.roleId == 1, cancellationToken).Result.ToList();
        var permission = permissions.Where(x => x.route == request.Data.Route).Select(x => x.permission).ToString();

        if (permission.ToCharArray()[0] == '1')
        {
            return true;
        }
        return false;
    }
}
