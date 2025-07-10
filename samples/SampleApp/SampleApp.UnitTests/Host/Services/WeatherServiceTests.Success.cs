namespace SampleApp.Host.Services;

partial class WeatherServiceTests
{
	[Theory]
	[InlineData(5)]
	[InlineData(10)]
	[InlineData(20)]
	public async Task GetWeatherForecastsAsync_GivenRequestCountIsWithinRange_CallsGettingUpstreamTelemetry(
		int requestCount
	)
	{
		// Arrange
		var telemetry = CreateTelemetry();
		var service = CreateService(telemetry);

		// Act
		await service.GetWeatherForecastsAsync(requestCount, TestContext.Current.CancellationToken);

		// Assert
		telemetry
			.Received(1)
			.GettingWeatherForecastFromUpstreamService(Arg.Any<string>(), requestCount);
	}
}
