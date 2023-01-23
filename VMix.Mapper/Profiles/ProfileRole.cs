namespace VMix.Mapper.Profiles;

internal class ProfileRole : Profile
{
    public ProfileRole()
    {
        CreateMap<AuthRole, GetRoleListDto>();
        CreateMap<CreateRoleDto, AuthRole>();
        CreateMap<AuthRole, GetRoleByIdDto>();
        CreateMap<UpdateRoleDto, AuthRole>();
        CreateMap<UpdateRoleByIdDto, AuthRole>();
        CreateMap<AuthRole, GetRoleListDto>();
    }
}
