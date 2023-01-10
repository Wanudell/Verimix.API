namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();

        var queriesAssembly = AppDomain.CurrentDomain.Load("Verimix.CQRS");
        var commandsAssembly = AppDomain.CurrentDomain.Load("Verimix.CQRS.Management");
        services.AddMediatR(queriesAssembly, commandsAssembly);

        return services;
    }
}