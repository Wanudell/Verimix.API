namespace VMix.Mapper.Profiles;

internal class ProfileUser : Profile
{
    public ProfileUser()
    {
        CreateMap<User, GetUserListDto>();
        CreateMap<CreateUserDto, User>();
        CreateMap<User, GetUserByIdDto>();
        CreateMap<UpdateUserDto, User>();
        CreateMap<UpdateUserByIdDto, User>();
        CreateMap<LoginUserDto, User>();
        CreateMap<RegisterUserDto, User>();
        CreateMap<RefreshTokenDto, User>();
        CreateMap<User, GetUserByTokenDto>();
        CreateMap<ResetPasswordDto, User>();

        CreateMap<ConfigNavMenu, ConfigNavMenuDto>();
        CreateMap<Permission, PermissionDto>();
    }
}