﻿namespace Purview.Telemetry.SourceGenerator.Metrics;

public partial class TelemetrySourceGeneratorMetricsTests(ITestOutputHelper testOutputHelper)
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
		var basicActivity =
			@$"
using Purview.Telemetry.Metrics;

namespace Testing;

[Meter(""testing-meter"")]
public interface ITestMetrics
{{
	[AutoCounter]
	void AutoCounter({parameterType} genericParameter);

	[Counter(AutoIncrement = true)]
	void Counter_AutoIncrement({parameterType} genericParameter);

	[Counter]
	void Counter([InstrumentMeasurement]int value, {parameterType} genericParameter);

	[Histogram]
	void Histogram([InstrumentMeasurement]int value, {parameterType} genericParameter);

	[UpDownCounter]
	void UpDownCounter([InstrumentMeasurement]int value, {parameterType} genericParameter);

	[ObservableCounter]
	void ObservableCounter(Func<int> valueFunc, {parameterType} genericParameter);

	[ObservableGauge]
	void ObservableGauge(Func<int> valueFunc, {parameterType} genericParameter);

	[ObservableUpDownCounter]
	void ObservableUpDownCounter(Func<int> valueFunc, {parameterType} genericParameter);
}}
";

		// Act
		var generationResult = await GenerateAsync(basicActivity);

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
		var basicMeter =
			@$"
using Purview.Telemetry.Metrics;

namespace Testing;

[Meter(""testing-meter"")]
public interface ITestMetrics<{genericTypeDef}>  {{
	[AutoCounter]
	void AutoCounter();
}}
";

		// Act
		var generationResult = await GenerateAsync(basicMeter);

		// Assert
		await TestHelpers.Verify(
			generationResult,
			c => c.ScrubInlineGuids(),
			expectsDiagnostics: true,
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
		var basicMeter =
			@$"
using Purview.Telemetry.Metrics;

namespace Testing;

[Meter(""testing-meter"")]
public interface ITestMetrics<{genericTypeDef}>  {{
	[AutoCounter]
	void AutoCounter();
}}
";

		// Act
		var generationResult = await GenerateAsync(basicMeter);

		// Assert
		await TestHelpers.Verify(
			generationResult,
			c => c.ScrubInlineGuids(),
			expectsDiagnostics: true,
			parameters: genericTypeCount
		);
	}
}
