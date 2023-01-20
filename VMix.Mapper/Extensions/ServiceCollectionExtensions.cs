namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(config =>
        {
            config.AddProfile<ProfileUser>();
            config.AddProfile<ProfileRole>();
            config.AddProfile<ProfileAuth>();
        });

        return services;
    }
}