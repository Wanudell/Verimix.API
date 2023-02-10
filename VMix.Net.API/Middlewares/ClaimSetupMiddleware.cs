namespace VMix.Net.API.Middlewares;

internal class ClaimSetupMiddleware
{
	private readonly RequestDelegate next;

	public ClaimSetupMiddleware(RequestDelegate next)
	{
		this.next = next;
	}

	public async Task InvokeAsync(HttpContext context, IClaims claims)
	{
		if (context.User.Identity.IsAuthenticated)
		{
			claims.IsAuthenticated = true;
			claims.CurrentUser.Id = int.Parse(context.User.Claims.First(f => f.Type == ClaimTypes.NameIdentifier).Value);
		}
		await next(context);
	}
}
