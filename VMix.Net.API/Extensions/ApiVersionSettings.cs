namespace Microsoft.Extensions.DependencyInjection
{
	public static class ApiVersionSettings
	{
		public static IServiceCollection AddVersionToApi(this IServiceCollection services)
		{
			services.AddApiVersioning(x =>
			{
				x.DefaultApiVersion = new ApiVersion(1, 0);
				x.AssumeDefaultVersionWhenUnspecified = true;
				x.ReportApiVersions = true;
				x.ApiVersionReader = ApiVersionReader.Combine(new HeaderApiVersionReader("x-api-version"), new QueryStringApiVersionReader("api-version"));
			});
			return services;
		}
	}
}
