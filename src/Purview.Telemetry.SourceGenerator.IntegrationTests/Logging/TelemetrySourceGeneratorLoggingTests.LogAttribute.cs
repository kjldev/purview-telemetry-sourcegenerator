namespace Purview.Telemetry.SourceGenerator.Logging;

partial class TelemetrySourceGeneratorLoggingTests
{
	[Theory]
	[MemberData(nameof(GetEntryNames))]
	public async Task Generate_GivenLogTargetWithEntryName_GenerateLogger(string logTargetName)
	{
		// Arrange
		var basicLogger =
			@$"
using Purview.Telemetry.Logging;

namespace Testing;

[Logger]
public interface ITestLogger {{
	[Log(Name = ""{logTargetName}"")]
	void Log(string stringParam, int intParam, bool boolParam);
}}
";

		// Act
		var generationResult = await GenerateAsync(basicLogger);

		// Assert
		await TestHelpers.Verify(generationResult, c => c.UseParameters(logTargetName));
	}

	[Theory]
	[MemberData(nameof(GetPrefixAndEntryNames))]
	public async Task Generate_GivenLogTargetWithPrefixAndEntryName_GenerateLogger(
		string type,
		string logTargetName
	)
	{
		// Arrange
		var prefixType = type switch
		{
			"Custom" => type + ", CustomPrefix = \"custom-prefix\"",
			_ => type,
		};

		var basicLogger =
			@$"
using Purview.Telemetry.Logging;

namespace Testing;

[Logger(PrefixType = LogPrefixType.{prefixType})]
public interface ITestLogger {{
	[Log(Name = ""{logTargetName}"")]
	void Log(string stringParam, int intParam, bool boolParam);
}}
";

		// Act
		var generationResult = await GenerateAsync(basicLogger);

		// Assert
		await TestHelpers.Verify(generationResult, c => c.UseParameters(prefixType, logTargetName));
	}

	public static TheoryData<string, string> GetPrefixAndEntryNames()
	{
		TheoryData<string, string> data = [];

		string[] prefixes = ["Default", "Custom", "Interface", "Class", "TrimmedClassName"];

		foreach (var type in prefixes)
		{
			foreach (var entryName in TestEntryNames)
			{
				data.Add(type, entryName);
			}
		}

		return data;
	}

	public static TheoryData<string> GetEntryNames()
	{
		TheoryData<string> data = [];

		foreach (var entryName in TestEntryNames)
		{
			data.Add(entryName);
		}

		return data;
	}

	static readonly string[] TestEntryNames =
	[
		"LogNameSetViaLogTargetAttribute",
		"CustomLogNameSetViaLogTargetAttribute",
		"123",
		"custom-log-entry-name",
	];
}
