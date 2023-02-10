namespace Microsoft.AspNetCore.Builder;

public static class ApplicationBuilderExtensions
{
	public static void UseClaims(this IApplicationBuilder app)
	{
		app.UseMiddleware<ClaimSetupMiddleware>();
	}
}


