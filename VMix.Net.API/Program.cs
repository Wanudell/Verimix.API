var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddData(builder.Configuration)
				.AddDataServices()
				.AddAutoMapper()
				.AddSwaggerDocs()
				.AddVersionToApi()
				.JWTBearerSettings(builder.Configuration)
				.WatchDogSettings(builder.Configuration);

var app = builder.Build();

app.SwaggerSettings();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseWatchDogExceptionLogger();
app.WatchDogAppSettings(builder.Configuration);
app.UseClaims();
app.MapControllers();

app.Run();

