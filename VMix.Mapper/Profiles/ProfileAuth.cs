namespace VMix.Mapper.Profiles;

internal class ProfileAuth : Profile
{
	public ProfileAuth()
	{
        CreateMap<ResetPasswordDto, User>();
        CreateMap<LoginUserDto, User>();
        CreateMap<RegisterUserDto, User>();
        CreateMap<RefreshTokenDto, User>();
    }
}
