namespace VMix.Net.API.Extensions;

public static class JWTBearerTokenSettings
{
    public static IServiceCollection JWTBearerSettings(this IServiceCollection services, IConfiguration config)
    {
			var key = config.GetValue<string>("Jwt:Key");
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                        ClockSkew = TimeSpan.Zero
                    };
                });
        services.AddAuthorization();
        services.AddScoped<IClaims, CurrentUserClaims>();
        return services;
    }
}
