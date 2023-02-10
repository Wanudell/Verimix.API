namespace VMix.Net.API.Extensions
{
    public static class SwaggerConfiguration
    {
        public static WebApplication SwaggerSettings(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(opt =>
                {
                    opt.SwaggerEndpoint(url: "/swagger/VMix.Net.API-Swagger-Docs/swagger.json", name: "VMix API Swagger v1");
                });
            }

            return app;
        }
    }
}
