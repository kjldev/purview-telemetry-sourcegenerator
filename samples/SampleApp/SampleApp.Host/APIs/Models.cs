using Microsoft.AspNetCore.Mvc;
using SampleApp.Host.Services;

record DefaultWeatherRequest(
	[FromServices] IWeatherService WeatherService,
	CancellationToken Token
);

record WeatherRequest(
	int RequestCount,
	[FromServices] IWeatherService WeatherService,
	CancellationToken Token
);
