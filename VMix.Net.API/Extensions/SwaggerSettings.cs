namespace VMix.Net.API.Extensions
{
    public static class SwaggerSettings
    {
        public static IServiceCollection AddSwaggerDocs(this IServiceCollection services)
        {
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc(name: "VMix.Net.API-Swagger-Docs", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "VMix.Net.API-Swagger-Docs",
                    Description = "Bu Backend Projesinde kullanılmış olan bütün teknolojiler Open-Source kod olmakta ve clean code mottosu ile yazılmaktadır. İstenildiği gibi revizyonlara açık halde olan Backend projemiz tamamiyle kullanıcı dostudur. İşlemlerin anlaşılır olması ve kod okunurluğu ön planda tutulmuştur.",
                    TermsOfService = new Uri("https://www.verimix.com.tr"),
                    Contact = new OpenApiContact
                    {
                        Name = "Berk Özerdoğan - Full Stack Developer",
                        Email = "berk.ozerdogan@verimix.net",
                        Url = new Uri("https://www.instagram.com/son4dakika")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Verimix Yazılım Licence - v1.0.0.1",
                        Url = new Uri("https://www.verimix.com.tr")
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                opt.IncludeXmlComments(xmlPath);
            });
            return services;
        }
    }
}
