namespace Purview.Telemetry.SourceGenerator.Logging;

public partial class TelemetrySourceGeneratorLoggingTests(ITestOutputHelper testOutputHelper)
	: IncrementalSourceGeneratorTestBase<TelemetrySourceGenerator>(testOutputHelper)
{
	[Theory]
	[MemberData(
		nameof(TelemetrySourceGeneratorTests.BasicGenericParameters),
		MemberType = typeof(TelemetrySourceGeneratorTests)
	)]
	public async Task Generate_GivenMethodWithBasicGenericParams_GeneratesEntryCorrectly(
		string parameterType
	)
	{
		// Arrange
		var basicLogger =
			@$"
using Purview.Telemetry.Logging;

namespace Testing;

[Logger]
public interface ITestLogger {{
	void LogEntryWithGenericTypeParam({parameterType} paramName);
}}
";

		// Act
		var generationResult = await GenerateAsync(basicLogger);

		// Assert
		await TestHelpers.Verify(
			generationResult,
			c => c.ScrubInlineGuids(),
			parameters: parameterType
		);
	}

	[Theory]
	[MemberData(
		nameof(TelemetrySourceGeneratorTests.GetGenericTypeDefCount),
		MemberType = typeof(TelemetrySourceGeneratorTests)
	)]
	public async Task Generate_GivenInterfaceWithGenerics_RaisesDiagnostics(int genericTypeCount)
	{
		// Arrange
		var genericTypeDef = string.Join(
			", ",
			Enumerable.Range(0, genericTypeCount).Select(i => $"T{i}")
		);
		var basicLogger =
			@$"
using Purview.Telemetry.Logging;

namespace Testing;

[Logger]
public interface ITestLogger<{genericTypeDef}> {{
	void LogEntryWithGenericTypeParam();
}}
";

		// Act
		var generationResult = await GenerateAsync(basicLogger);

		// Assert
		await TestHelpers.Verify(
			generationResult,
			c => c.ScrubInlineGuids(),
			validateNonEmptyDiagnostics: true,
			parameters: genericTypeCount
		);
	}

	[Theory]
	[MemberData(
		nameof(TelemetrySourceGeneratorTests.GetGenericTypeDefCount),
		MemberType = typeof(TelemetrySourceGeneratorTests)
	)]
	public async Task Generate_GivenMethodWithGenerics_RaisesDiagnostics(int genericTypeCount)
	{
		// Arrange
		var genericTypeDef = string.Join(
			", ",
			Enumerable.Range(0, genericTypeCount).Select(i => $"T{i}")
		);
		var basicLogger =
			@$"
using Purview.Telemetry.Logging;

namespace Testing;

[Logger]
public interface ITestLogger<{genericTypeDef}> {{
	void LogEntryWithGenericTypeParam();
}}
";

		// Act
		var generationResult = await GenerateAsync(basicLogger);

		// Assert
		await TestHelpers.Verify(
			generationResult,
			c => c.ScrubInlineGuids(),
			validateNonEmptyDiagnostics: true,
			parameters: genericTypeCount
		);
	}
}
