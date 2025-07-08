using System.Diagnostics;

namespace SampleApp.Host.Services;

partial class WeatherServiceTests
{
	[Fact]
	public async Task GetWeatherForecastsAsync_GivenSimulatedUpstreamFails_CallsFailureActivityEventAndLog()
	{
		// Arrange
		const int requestCount = 10;
		var telemetry = CreateTelemetry();
		var service = CreateService(telemetry, throwOnRNG: true);

		using Activity activity = new(
			nameof(
				GetWeatherForecastsAsync_GivenSimulatedUpstreamFails_CallsFailureActivityEventAndLog
			)
		);
		telemetry
			.GettingWeatherForecastFromUpstreamService(Arg.Any<string>(), requestCount)
			.Returns(activity);

		// Act
		var act = () =>
			service.GetWeatherForecastsAsync(requestCount, TestContext.Current.CancellationToken);

		// Assert
		var ex = await Should.ThrowAsync<Exception>(act);

		telemetry.Received(1).FailedToRetrieveForecast(activity, ex);
		telemetry.Received(1).WeatherForecastRequestFailed(ex);
	}
}
