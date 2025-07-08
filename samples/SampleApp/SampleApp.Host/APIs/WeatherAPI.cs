using Microsoft.AspNetCore.Http.HttpResults;
using SampleApp.Host.Services;

namespace SampleApp.Host.APIs;

static class WeatherAPI
{
	public static IEndpointRouteBuilder MapWeatherAPIv1(this IEndpointRouteBuilder app)
	{
		var api = app.MapGroup("/weatherforecast")
			//.MapToApiVersion(1.0)
			.WithDisplayName("Weather APIs");

		api.MapGet("/", GetDefaultWeatherRequestAsync)
			.WithDescription("Gets the weather forecasts, defaults to 5.")
			.WithDisplayName("5 Weather Forecasts");

		api.MapGet("/{requestCount:int}", GetWeatherRequestAsync)
			.WithDescription("Gets the weather forecasts.")
			.WithDisplayName("Weather Forecasts");

		return api;
	}

	static async Task<
		Results<Ok<WeatherForecast[]>, NoContent, ProblemHttpResult>
	> GetDefaultWeatherRequestAsync([AsParameters] DefaultWeatherRequest request)
	{
		try
		{
			var results = await request.WeatherService.GetWeatherForecastsAsync(5, request.Token);
			return results.Any() ? TypedResults.Ok(results.ToArray()) : TypedResults.NoContent();
		}
		catch (Exception ex)
		{
			return TypedResults.Problem(detail: ex.Message, statusCode: 502);
		}
	}

	static async Task<
		Results<Ok<WeatherForecast[]>, NoContent, ProblemHttpResult, BadRequest<string>>
	> GetWeatherRequestAsync([AsParameters] WeatherRequest request)
	{
		try
		{
			var results = await request.WeatherService.GetWeatherForecastsAsync(
				request.RequestCount,
				request.Token
			);
			return results.Any() ? TypedResults.Ok(results.ToArray()) : TypedResults.NoContent();
		}
		catch (ArgumentOutOfRangeException ex)
		{
			return TypedResults.BadRequest(ex.Message);
		}
		catch (Exception ex)
		{
			return TypedResults.Problem(detail: ex.Message, statusCode: 502);
		}
	}
}
