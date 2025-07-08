﻿namespace Purview.Telemetry.SourceGenerator.Logging;

partial class TelemetrySourceGeneratorLoggingTests
{
	[Theory]
	[MemberData(nameof(SpecificLogAttributeTypes))]
	public async Task Generate_GivenInterfaceWithSpecificLogAttribute_GenerateLoggerWithThatLevel(
		string attribute
	)
	{
		// Arrange
		string basicLogger =
			@$"
using Purview.Telemetry.Logging;

namespace Testing;

[Logger]
public interface ITestLogger 
{{
	[{attribute}]
	void Log(string stringParam, int intParam, bool boolParam);
}}
";

		// Act
		var generationResult = await GenerateAsync(basicLogger);

		// Assert
		await TestHelpers.Verify(generationResult, c => c.UseParameters(attribute));
	}

	[Theory]
	[MemberData(nameof(SpecificLogAttributeTypes))]
	public async Task Generate_GivenInterfaceWithSpecificTypesAndSpecificParameters_GenerateLoggerWithThatLevelAndParameter(
		string attribute
	)
	{
		// Arrange
		string basicLogger =
			@$"
using Purview.Telemetry.Logging;

namespace Testing;

[Logger]
public interface ITestLogger 
{{
	[{attribute}]
	void Log(string stringParam, int intParam, bool boolParam);

	[{attribute}(eventId: 100)]
	void Log_EventId_1(string stringParam, int intParam, bool boolParam);

	[{attribute}(100)]
	void Log_EventId_3(string stringParam, int intParam, bool boolParam);

	[{attribute}(messageTemplate: ""template"")]
	void Log_MessageTemplate_1(string stringParam, int intParam, bool boolParam);

	[{attribute}(MessageTemplate = ""template"")]
	void Log_MessageTemplate_2(string stringParam, int intParam, bool boolParam);

	[{attribute}(""template"")]
	void Log_MessageTemplate_3(string stringParam, int intParam, bool boolParam);
}}
";

		// Act
		var generationResult = await GenerateAsync(basicLogger);

		// Assert
		await TestHelpers.Verify(generationResult, c => c.UseParameters(attribute));
	}

	public static TheoryData<string> SpecificLogAttributeTypes
	{
		get
		{
			TheoryData<string> data = [];

			data.Add("Trace");
			data.Add("Debug");
			data.Add("Info");
			data.Add("Warning");
			data.Add("Error");
			data.Add("Critical");

			return data;
		}
	}
}
