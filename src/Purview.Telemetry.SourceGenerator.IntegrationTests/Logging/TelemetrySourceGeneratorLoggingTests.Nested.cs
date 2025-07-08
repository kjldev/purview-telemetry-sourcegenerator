namespace Purview.Telemetry.SourceGenerator.Logging;

partial class TelemetrySourceGeneratorLoggingTests
{
	[Theory]
	[InlineData("Testing.Test1")]
	[InlineData("Testing.Test1.Test2")]
	[InlineData("Testing.Test1.Test2.Test3")]
	public async Task Generate_GivenLoggerWithNamespaces_GeneratesScopedLogTarget(string @namespace)
	{
		// Arrange
		var basicLogger =
			@$"
using Purview.Telemetry.Logging;

namespace {@namespace};

[Logger]
public interface ITestLogger {{
	IDisposable Log(string stringParam, int intParam);
}}
";

		// Act
		var generationResult = await GenerateAsync(basicLogger);

		// Assert
		await TestHelpers.Verify(
			generationResult,
			c => c.ScrubInlineGuids().UseParameters(@namespace)
		);
	}

	[Theory]
	[InlineData("Testing.Test1")]
	[InlineData("Testing.Test1.Test2")]
	[InlineData("Testing.Test1.Test2.Test3")]
	public async Task Generate_GivenLoggerWithNamespacesAndNestedClass_GeneratesScopedLogTarget(
		string @namespace
	)
	{
		// Arrange
		var basicLogger =
			@$"
using Purview.Telemetry.Logging;

namespace {@namespace};

public partial class TestClass1 {{
	[Logger]
	public interface ITestLogger {{
		IDisposable Log(string stringParam, int intParam);
	}}
}}
";

		// Act
		var generationResult = await GenerateAsync(basicLogger);

		// Assert
		await TestHelpers.Verify(
			generationResult,
			c => c.ScrubInlineGuids().UseParameters(@namespace)
		);
	}

	[Theory]
	[InlineData("Testing.Test1")]
	[InlineData("Testing.Test1.Test2")]
	[InlineData("Testing.Test1.Test2.Test3")]
	public async Task Generate_GivenLoggerWithNamespacesAndNestedClasses_GeneratesScopedLogTarget(
		string @namespace
	)
	{
		// Arrange
		var basicLogger =
			@$"
using Purview.Telemetry.Logging;

namespace {@namespace};

public partial class TestClass1 {{
	public partial class TestClass2 {{
		public partial class TestClass3 {{
			[Logger]
			public interface ITestLogger {{
				IDisposable Log(string stringParam, int intParam);
			}}
		}}
	}}
}}
";

		// Act
		var generationResult = await GenerateAsync(basicLogger);

		// Assert
		await TestHelpers.Verify(
			generationResult,
			c => c.ScrubInlineGuids().UseParameters(@namespace)
		);
	}
}
