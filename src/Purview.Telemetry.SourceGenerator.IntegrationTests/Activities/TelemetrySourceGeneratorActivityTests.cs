﻿namespace Purview.Telemetry.SourceGenerator.Activities;

public partial class TelemetrySourceGeneratorActivityTests(ITestOutputHelper testOutputHelper)
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
using Purview.Telemetry.Activities;

namespace Testing;

[ActivitySource]
public interface ITestActivities 
{{
	[Activity]
	System.Diagnostics.Activity? Activity({parameterType} paramName);

	[Event]
	void Event(System.Diagnostics.Activity? activity, {parameterType} paramName);

	[Context]
	void Context(System.Diagnostics.Activity? activity, {parameterType} paramName);
}}
";

		// Act
		var generationResult = await GenerateAsync(basicActivity);

		// Assert
		await TestHelpers.Verify(
			generationResult,
			c => c.ScrubInlineGuids().UseParameters(parameterType)
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
		var basicActivity =
			@$"
using Purview.Telemetry.Activities;

namespace Testing;

[ActivitySource]
public interface ITestActivities<{genericTypeDef}>
{{
	[Activity]
	System.Diagnostics.Activity? Activity();
}}
";

		// Act
		var generationResult = await GenerateAsync(basicActivity);

		// Assert
		await TestHelpers.Verify(
			generationResult,
			c => c.ScrubInlineGuids().UseParameters(genericTypeCount),
			validateNonEmptyDiagnostics: true
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
		var basicActivity =
			@$"
using Purview.Telemetry.Activities;

namespace Testing;

[ActivitySource]
public interface ITestActivities
{{
	[Activity]
	System.Diagnostics.Activity? Activity<{genericTypeDef}>();
}}
";

		// Act
		var generationResult = await GenerateAsync(basicActivity);

		// Assert
		await TestHelpers.Verify(
			generationResult,
			c => c.ScrubInlineGuids().UseParameters(genericTypeCount),
			validateNonEmptyDiagnostics: true
		);
	}
}
