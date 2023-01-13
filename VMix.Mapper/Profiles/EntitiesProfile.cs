using VMix.CQRS.Contracts.UserContracts;

namespace VMix.Mapper.Profiles
{
    internal class EntitiesProfile : Profile
    {
        public EntitiesProfile()
        {
            CreateMap<User, UserListDto>();
            CreateMap<NewUserDto, User>();
            CreateMap<User, UserByIdDto>();
            CreateMap<UpdateUserDto, User>();
            CreateMap<UpdateUserByIdDto, User>();
            CreateMap<LoginUserDto, User>();
            CreateMap<RegisterUserDto, User>();
            CreateMap<RefreshTokenDto, User>();
        }
    }
}