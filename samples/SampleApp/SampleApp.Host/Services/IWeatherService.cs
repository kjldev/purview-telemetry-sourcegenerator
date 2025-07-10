namespace SampleApp.Host.Services;

public interface IWeatherService
{
	Task<IEnumerable<WeatherForecast>> GetWeatherForecastsAsync(
		int requestCount,
		CancellationToken cancellationToken = default
	);
}
