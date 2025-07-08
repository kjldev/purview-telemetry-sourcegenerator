namespace SampleApp.Host.Services;

partial class WeatherServiceTests
{
	[Theory]
	[InlineData(1)]
	[InlineData(4)]
	[InlineData(21)]
	[InlineData(221)]
	public async Task GetWeatherForecastsAsync_GivenRequestCountIsOutOfRange_ThrowsAndLogs(
		int requestCount
	)
	{
		// Arrange
		var telemetry = CreateTelemetry();
		var service = CreateService(telemetry);

		// Act
		var act = () =>
			service.GetWeatherForecastsAsync(requestCount, TestContext.Current.CancellationToken);

		// Assert
		await Should.ThrowAsync<ArgumentOutOfRangeException>(act);

		telemetry.Received(1).RequestedCountIsTooSmall(requestCount);
	}
}
