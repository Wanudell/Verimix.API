namespace VMix.Mapper.Profiles;

internal class ProfileAuth : Profile
{
	public ProfileAuth()
	{
        CreateMap<ResetPasswordDto, AuthUser>();
        CreateMap<LoginUserDto, AuthUser>();
        CreateMap<RegisterUserDto, AuthUser>();
        CreateMap<RefreshTokenDto, AuthUser>();
    }
}
