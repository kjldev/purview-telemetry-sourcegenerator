namespace Purview.Telemetry.SourceGenerator.Logging;

partial class TelemetrySourceGeneratorLoggingTests
{
	[Fact]
	public async Task Generate_GivenInterfaceWithSingleBasicExplicitLogEntry_GenerateLogger()
	{
		// Arrange
		const string basicLogger =
			@"
using Purview.Telemetry.Logging;

namespace Testing;

[Logger]
public interface ITestLogger {
	[Log]
	void Log(string stringParam, int intParam, bool boolParam);
}
";

		// Act
		var generationResult = await GenerateAsync(basicLogger);

		// Assert
		await TestHelpers.Verify(generationResult);
	}

	[Fact]
	public async Task Generate_GivenInterfaceWithSingleBasicImplicitLogEntry_GenerateLogger()
	{
		// Arrange
		const string basicLogger =
			@"
using Purview.Telemetry.Logging;

namespace Testing;

[Logger]
public interface ITestLogger {
	void Log(string stringParam, int intParam, bool boolParam);
}
";

		// Act
		var generationResult = await GenerateAsync(basicLogger);

		// Assert
		await TestHelpers.Verify(generationResult);
	}

	[Theory]
	[InlineData("Level = Microsoft.Extensions.Logging.LogLevel.Trace")]
	[InlineData("level: Microsoft.Extensions.Logging.LogLevel.Trace")]
	[InlineData("Microsoft.Extensions.Logging.LogLevel.Trace")]
	public async Task Generate_GivenInterfaceWithExplicitLogLevelAndAnExceptionParameter_GenerateLogger(
		string level
	)
	{
		// Arrange
		var basicLogger =
			@$"
using Purview.Telemetry.Logging;

namespace Testing;

[Logger]
public interface ITestLogger {{
	[Log({level})]
	void Log(string stringParam, int intParam, bool boolParam, Exception exception);
}}
";

		// Act
		var generationResult = await GenerateAsync(basicLogger);

		// Assert
		await TestHelpers.Verify(generationResult, c => c.ScrubInlineGuids(), parameters: level);
	}

	[Fact]
	public async Task Generate_GivenInterfaceWithoutExplicitLogLevelAndAnExceptionParameter_GenerateLogger()
	{
		// Arrange
		const string basicLogger =
			@"
using Purview.Telemetry.Logging;

namespace Testing;

[Logger]
public interface ITestLogger {
	void Log(string stringParam, int intParam, bool boolParam, Exception exception);
}
";

		// Act
		var generationResult = await GenerateAsync(basicLogger);

		// Assert
		await TestHelpers.Verify(
			generationResult,
			c => c.ScrubInlineGuids(),
			validateNonEmptyDiagnostics: true
		);
	}

	[Fact]
	public async Task Generate_GivenInterfaceMoreThanSixParameters_RaisesDiagnostic()
	{
		// Arrange
		const string basicLogger =
			@"
using Purview.Telemetry.Logging;

namespace Testing;

[Logger]
public interface ITestLogger {
	void Log(string stringParam, int intParam, bool boolParam, string stringParam1, int intParam1, bool boolParam1, string stringParam2, int intParam2, bool boolParam2);
}
";

		// Act
		var generationResult = await GenerateAsync(basicLogger);

		// Assert
		await TestHelpers.Verify(
			generationResult,
			c => c.ScrubInlineGuids(),
			validateNonEmptyDiagnostics: true,
			validationCompilation: false
		);
	}

	[Fact]
	public async Task Generate_GivenInterfaceMoreThanOneExceptionParameter_RaisesDiagnostic()
	{
		// Arrange
		const string basicLogger =
			@"
using Purview.Telemetry.Logging;

namespace Testing;

[Logger]
public interface ITestLogger {
	void Log(string stringParam, Exception exception1, Exception exception2);
}
";

		// Act
		var generationResult = await GenerateAsync(basicLogger);

		// Assert
		await TestHelpers.Verify(
			generationResult,
			c => c.ScrubInlineGuids(),
			validateNonEmptyDiagnostics: true,
			validationCompilation: false
		);
	}

	[Fact]
	public async Task Generate_GivenMethodReturnsIDisposable_GeneratesScopedLogEntry()
	{
		// Arrange
		const string basicLogger =
			@"
using Purview.Telemetry.Logging;

namespace Testing;

[Logger]
public interface ITestLogger {
	IDisposable Log();
}
";

		// Act
		var generationResult = await GenerateAsync(basicLogger);

		// Assert
		await TestHelpers.Verify(generationResult, c => c.ScrubInlineGuids());
	}

	[Fact]
	public async Task Generate_GivenMethodWithParamsAndExceptionReturnsIDisposable_GeneratesScopedLogEntry()
	{
		// Arrange
		const string basicLogger =
			@"
using Purview.Telemetry.Logging;

namespace Testing;

[Logger]
public interface ITestLogger {
	IDisposable Log(string stringParam, int intParam, Exception exception);
}
";

		// Act
		var generationResult = await GenerateAsync(basicLogger);

		// Assert
		await TestHelpers.Verify(generationResult, c => c.ScrubInlineGuids());
	}

	[Fact]
	public async Task Generate_GivenMethodWithParamsReturnsIDisposable_GeneratesScopedLogEntry()
	{
		// Arrange
		const string basicLogger =
			@"
using Purview.Telemetry.Logging;

namespace Testing;

[Logger]
public interface ITestLogger {
	IDisposable Log(string stringParam, int intParam);
}
";

		// Act
		var generationResult = await GenerateAsync(basicLogger);

		// Assert
		await TestHelpers.Verify(generationResult, c => c.ScrubInlineGuids());
	}
}
