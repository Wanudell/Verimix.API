namespace Verimix.API.WatchDog
{
	public static class WatchDogConfigurations
	{
		public static IServiceCollection WatchDogSettings(this IServiceCollection services, ConfigurationManager config)
		{
			var settings = config.GetConnectionString("WatchDogDb");
			services.AddWatchDogServices(opt =>
			{
				opt.IsAutoClear = false;
				opt.ClearTimeSchedule = WatchDogAutoClearScheduleEnum.Monthly;
				opt.SetExternalDbConnString = settings;
				opt.SqlDriverOption = WatchDogSqlDriverEnum.MSSQL;
			});

			return services;

		}
	}
}