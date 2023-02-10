namespace VMix.Mapper.Profiles;

internal class ProfileUser : Profile
{
    public ProfileUser()
    {
        CreateMap<AuthUser, GetUserListDto>();
        CreateMap<CreateUserDto, AuthUser>();
        CreateMap<AuthUser, GetUserByIdDto>();
        CreateMap<UpdateUserDto, AuthUser>();
        CreateMap<UpdateUserByIdDto, AuthUser>();
        CreateMap<LoginUserDto, AuthUser>();
        CreateMap<RegisterUserDto, AuthUser>();
        CreateMap<RefreshTokenDto, AuthUser>();
        CreateMap<AuthUser, GetUserByTokenDto>();
        CreateMap<ResetPasswordDto, AuthUser>();

        CreateMap<ConfigNavMenu, ConfigNavMenuDto>();
        CreateMap<AuthPermission, PermissionDto>();
    }
}