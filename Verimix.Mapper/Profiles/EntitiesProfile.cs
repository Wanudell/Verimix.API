namespace Verimix.Mapper.Profiles
{
    internal class EntitiesProfile : Profile
    {
        public EntitiesProfile()
        {
            CreateMap<User, UserListDto>();
            CreateMap<NewUserDto, User>();
            CreateMap<User, UserByIdDto>();
            CreateMap<UpdateUserDto, User>();
        }
    }
}