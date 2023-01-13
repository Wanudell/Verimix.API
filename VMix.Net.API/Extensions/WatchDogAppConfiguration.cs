namespace VMix.Net.API.Extensions
{
    public static class WatchDogAppConfiguration
    {
        public static WebApplication WatchDogAppSettings(this WebApplication app, IConfiguration config)
        {
            var username = config.GetValue<string>("WatchDog:UserName");
            var password = config.GetValue<string>("WatchDog:Password");

            app.UseWatchDog(opt =>
            {
                opt.WatchPageUsername = username;
                opt.WatchPagePassword = password;
                opt.Blacklist = "";
            });

            return app;
        }
    }
}
