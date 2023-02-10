namespace VMix.CQRS.Management.QuerieHandlers.NavMenuQueryHandler;

public class GetNavMenuRequestHandler : IRequestHandler<GetNavMenuRequest, List<NavMenuResultDto>>
{
    private readonly IUnitOfWork unitOfWork;

    public GetNavMenuRequestHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<List<NavMenuResultDto>> Handle(GetNavMenuRequest request, CancellationToken cancellationToken)
    {
        var token = request.Token;
        var roleId = unitOfWork.GetRepository<AuthUser>().GetAll<GetUserListDto>(x => x.token == token, cancellationToken).Result.Select(x => x.roleId).FirstOrDefault();
        var allowedRoutes = unitOfWork.GetRepository<AuthPermission>().GetAll<PermissionDto>(x => x.roleId == roleId && Convert.ToInt32(x.permission) >= 100, cancellationToken).Result.Select(x => x.route).ToList();
        var navMenu = unitOfWork.GetRepository<ConfigNavMenu>().GetAll<ConfigNavMenuDto>(x => x.isHeader, cancellationToken).Result.OrderBy(x => x.lineNr).ToList();
        var headerNodes = navMenu.Where(x => x.isHeader).OrderBy(x => x.lineNr).ToList();

        var navMenuJson = new List<NavMenuResultDto>();
        foreach (var node in headerNodes)
        {
            var parentNodes = navMenu.Where(x => x.parentNodeID == node.id && (x.href == null || allowedRoutes.Contains(x.href))).OrderBy(x => x.lineNr).ToList();
            if (parentNodes.Count() != 0)
            {
                NavMenuResultDto navMenuHeaderItem = new NavMenuResultDto();
                navMenuHeaderItem.header = true;
                navMenuHeaderItem.title = node.title;

                foreach (var parentNode in parentNodes)
                {
                    var childNodes = navMenu.Where(x => x.parentNodeID == parentNode.id && (x.href == null || allowedRoutes.Contains(x.href))).OrderBy(x => x.lineNr).ToList();
                    if (childNodes.Count() == 0 && parentNode.href != null)
                    {
                        navMenuJson.Add(navMenuHeaderItem);
                        NavMenuResultDto navMenuItem = new NavMenuResultDto();
                        navMenuItem.title = parentNode.title;
                        navMenuItem.icon = parentNode.icon;
                        navMenuItem.href = parentNode.href;
                        navMenuJson.Add(navMenuItem);
                    }
                    else if (childNodes.Count() != 0)
                    {
                        navMenuJson.Add(navMenuHeaderItem);
                        List<Child> navMenuChildItemList = new List<Child>();
                        foreach (var childItem in childNodes)
                        {
                            Child navMenuChildItem = new Child();
                            navMenuChildItem.title = childItem.title;
                            navMenuChildItem.href = childItem.href;
                            navMenuChildItemList.Add(navMenuChildItem);
                        };

                        NavMenuResultDto navMenuItem = new NavMenuResultDto();
                        navMenuItem.title = parentNode.title;
                        navMenuItem.icon = parentNode.icon;
                        navMenuItem.child = navMenuChildItemList;
                        navMenuJson.Add(navMenuItem);
                    }
                }
            }
        }
        
        return navMenuJson;
    }
}

