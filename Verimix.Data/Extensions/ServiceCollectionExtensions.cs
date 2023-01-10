namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<DbContext, VerimixDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            var section = configuration.GetSection($"{nameof(Settings)}:Database");
            var settings = section.Get<Settings.DatabaseConfiguration>();
            services.AddDbContext<VerimixDbContext>(builder =>
            {
                builder.UseSqlServer(settings.ConnectionString);
            });

            return services;
        }
    }
}