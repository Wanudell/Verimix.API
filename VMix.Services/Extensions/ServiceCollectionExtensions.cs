namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();

        var queriesAssembly = AppDomain.CurrentDomain.Load("VMix.CQRS");
        var commandsAssembly = AppDomain.CurrentDomain.Load("VMix.CQRS.Management");
        services.AddMediatR(queriesAssembly, commandsAssembly);

        return services;
    }
}