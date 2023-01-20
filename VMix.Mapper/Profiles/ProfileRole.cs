namespace VMix.Mapper.Profiles;

internal class ProfileRole : Profile
{
    public ProfileRole()
    {
        CreateMap<Role, GetRoleListDto>();
        CreateMap<CreateRoleDto, Role>();
        CreateMap<Role, GetRoleByIdDto>();
        CreateMap<UpdateRoleDto, Role>();
        CreateMap<UpdateRoleByIdDto, Role>();
        CreateMap<Role, GetRoleListDto>();
    }
}
