using SampleApp.Host.APIs;
using SampleApp.Host.Services;

var builder = WebApplication.CreateSlimBuilder(args);

builder
	.AddServiceDefaults()
	.AddDefaultOpenAPI(
	//builder.Services.AddApiVersioning()
	);

builder.Services.AddScoped<IWeatherService, WeatherService>().AddWeatherServiceTelemetry();

var app = builder.Build();

app.MapDefaultEndpoints();

//app
//.NewVersionedApi("Weather API")
//.MapToApiVersion(1.0)
//;

app.MapWeatherAPIv1();

app.UseDefaultOpenAPI();

await app.RunAsync();
