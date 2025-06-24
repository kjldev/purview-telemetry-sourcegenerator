namespace Purview.Telemetry.SourceGenerator;

partial class TelemetrySourceGeneratorTests
{
	[Fact]
	public async Task Generate_GivenPartialInterfaces_GeneratesTelemetry()
	{
		// Arrange
		const string partialInterfacePart1 =
			@"
using Purview.Telemetry.Activities;
using Purview.Telemetry.Logging;
using Purview.Telemetry.Metrics;

namespace Testing.PartialInterfaces;

[ActivitySource(""activity-source"")]
[Logger]
[Meter]
partial interface ITestTelemetry
{
	[Event]
	void Event(System.Diagnostics.Activity? activity, [Baggage]string stringParam, [Tag]int intParam, bool boolParam);

	[Context]
	void Context(System.Diagnostics.Activity? activity, [Baggage]string stringParam, [Tag]int intParam, bool boolParam);

	[Log]
	void Log([Tag]int intParam, bool boolParam);
}
";

		const string partialInterfacePart2 =
			@"
using Purview.Telemetry.Activities;
using Purview.Telemetry.Logging;
using Purview.Telemetry.Metrics;

namespace Testing.PartialInterfaces;

partial interface ITestTelemetry
{
	[Event]
	void Event(System.Diagnostics.Activity? activity, [Baggage]string stringParam, [Tag]int intParam, bool boolParam);

	[Context]
	void Context(System.Diagnostics.Activity? activity, [Baggage]string stringParam, [Tag]int intParam, bool boolParam);

	[Log]
	IDisposable? LogScope([Tag]int intParam, bool boolParam);

	[Counter]
	bool Counter(int counterValue, [Tag]int intParam, bool boolParam);
}
";
		// Act
		var generationResult = await GenerateAsync(
			csharpDocuments: [Text(partialInterfacePart1), Text(partialInterfacePart2)]
		);

		// Assert
		await TestHelpers.Verify(generationResult);
	}

	[Fact]
	public async Task Generate_GivenNoNamespace_GeneratesTelemetry()
	{
		// Arrange
		const string basicTelemetry =
			@"
using Purview.Telemetry.Activities;
using Purview.Telemetry.Logging;
using Purview.Telemetry.Metrics;

[ActivitySource(""activity-source"")]
[Logger]
[Meter]
public interface ITestTelemetry
{
	[Activity]
	System.Diagnostics.Activity? Activity([Baggage]string stringParam, [Tag]int intParam, bool boolParam);

	[Event]
	void Event(System.Diagnostics.Activity? activity, [Baggage]string stringParam, [Tag]int intParam, bool boolParam);

	[Context]
	void Context(System.Diagnostics.Activity? activity, [Baggage]string stringParam, [Tag]int intParam, bool boolParam);

	[Log]
	void Log([Tag]int intParam, bool boolParam);

	[Log]
	IDisposable? LogScope([Tag]int intParam, bool boolParam);

	[Counter]
	bool Counter(int counterValue, [Tag]int intParam, bool boolParam);
}
";

		// Act
		var generationResult = await GenerateAsync(basicTelemetry);

		// Assert
		await TestHelpers.Verify(generationResult);
	}

	[Fact]
	public async Task Generate_GivenBasicTelemetryGen_GeneratesTelemetry()
	{
		// Arrange
		const string basicTelemetry =
			@"
using Purview.Telemetry.Activities;
using Purview.Telemetry.Logging;
using Purview.Telemetry.Metrics;

namespace Testing;

[ActivitySource(""activity-source"")]
[Logger]
[Meter]
public interface ITestTelemetry
{
	[Activity]
	System.Diagnostics.Activity? Activity([Baggage]string stringParam, [Tag]int intParam, bool boolParam);

	[Event]
	void Event(System.Diagnostics.Activity? activity, [Baggage]string stringParam, [Tag]int intParam, bool boolParam);

	[Context]
	void Context(System.Diagnostics.Activity? activity, [Baggage]string stringParam, [Tag]int intParam, bool boolParam);

	[Log]
	void Log([Tag]int intParam, bool boolParam);

	[Log]
	IDisposable? LogScope([Tag]int intParam, bool boolParam);

	[Counter]
	bool Counter(int counterValue, [Tag]int intParam, bool boolParam);
}
";

		// Act
		var generationResult = await GenerateAsync(basicTelemetry);

		// Assert
		await TestHelpers.Verify(generationResult);
	}

	[Fact]
	public async Task Generate_GivenBasicEventWithException_GeneratesTelemetry()
	{
		// Arrange
		const string basicTelemetry =
			@"
using Purview.Telemetry.Activities;

namespace Testing;

[ActivitySource(""activity-source"")]
public interface ITestTelemetry
{
	[Activity]
	System.Diagnostics.Activity? Activity();

	[Event]
	void Event(System.Diagnostics.Activity? activity, [Baggage]string stringParam, [Tag]int intParam, bool boolParam, Exception anException);
}
";

		// Act
		var generationResult = await GenerateAsync(basicTelemetry);

		// Assert
		await TestHelpers.Verify(generationResult);
	}

	[Fact]
	public async Task Generate_GivenBasicEventWithExceptionAndEscape_GeneratesTelemetry()
	{
		// Arrange
		const string basicTelemetry =
			@"
using Purview.Telemetry.Activities;

namespace Testing;

[ActivitySource(""activity-source"")]
public interface ITestTelemetry
{
	[Activity]
	System.Diagnostics.Activity? Activity();

	[Event]
	void Event(System.Diagnostics.Activity? activity, [Baggage]string stringParam, [Tag]int intParam, bool boolParam, Exception anException, [Escape]bool escape);
}
";

		// Act
		var generationResult = await GenerateAsync(basicTelemetry);

		// Assert
		await TestHelpers.Verify(generationResult);
	}

	[Fact]
	public async Task Generate_GivenBasicEventWithExceptionAndDisabledOTelExceptionRulesAndEscape_GeneratesTelemetry()
	{
		// Arrange
		const string basicTelemetry =
			@"
using Purview.Telemetry.Activities;

namespace Testing;

[ActivitySource(""activity-source"")]
public interface ITestTelemetry
{
	[Activity]
	System.Diagnostics.Activity? Activity();

	[Event(UseRecordExceptionRules = false)]
	void EventMethod(System.Diagnostics.Activity? activity, [Baggage]string stringParam, [Tag]int intParam, bool boolParam, Exception anException, [Escape]bool escape);
}
";

		// Act
		var generationResult = await GenerateAsync(basicTelemetry);

		// Assert
		await TestHelpers.Verify(generationResult);
	}

	[Fact]
	public async Task Generate_GivenBasicEventWithExplicitExceptionAndNamedExceptionAndRulesAreFalse_GeneratesTelemetry()
	{
		// Arrange
		const string basicTelemetry =
			@"
using Purview.Telemetry.Activities;

namespace Testing;

[ActivitySource(""activity-source"")]
public interface ITestTelemetry
{
	[Activity]
	System.Diagnostics.Activity? Activity();

	[Event(name: ""exception"", UseRecordExceptionRules = false)]
	void EventMethod(System.Diagnostics.Activity? activity, [Baggage]string stringParam, [Tag]int intParam, bool boolParam, Exception anException, [Escape]bool escape);
}
";

		// Act
		var generationResult = await GenerateAsync(basicTelemetry);

		// Assert
		await TestHelpers.Verify(generationResult);
	}

	[Fact]
	public async Task Generate_GivenBasicEventWithExplicitExceptionAndEventIsNamedExceptionAndRulesAreTrue_GeneratesTelemetry()
	{
		// Arrange
		const string basicTelemetry =
			@"
using Purview.Telemetry.Activities;

namespace Testing;
	
[ActivitySource(""activity-source"")]
public interface ITestTelemetry
{
	[Activity]
	System.Diagnostics.Activity? Activity();

	[Event(name: ""exception"", UseRecordExceptionRules = true)]
	void EventMethod(System.Diagnostics.Activity? activity, [Baggage]string stringParam, [Tag]int intParam, bool boolParam, Exception anException, [Escape]bool escape);
}
";

		// Act
		var generationResult = await GenerateAsync(basicTelemetry);

		// Assert
		await TestHelpers.Verify(generationResult);
	}

	[Fact]
	public async Task Generate_GivenDuplicateTelemetryGen_GeneratesDiagnostics()
	{
		// Arrange
		const string basicTelemetry =
			@"
using Purview.Telemetry.Activities;
using Purview.Telemetry.Logging;
using Purview.Telemetry.Metrics;

namespace Testing;

[ActivitySource(""activity-source"")]
[Logger]
[Meter]
public interface ITestTelemetry
{
	[Activity]
	[Log]
	void Activity([Baggage]string stringParam, [Tag]int intParam, bool boolParam);

	[Event]
	[Counter]
	void Event([Baggage]string stringParam, [Tag]int intParam, bool boolParam);

	[Context]
	[Activity]
	void Context([Baggage]string stringParam, [Tag]int intParam, bool boolParam);

	[Log]
	[Counter]
	void Log([Tag]int intParam, bool boolParam);

	[Log]
	[Activity]
	IDisposable? LogScope([Tag]int intParam, bool boolParam);

	[Counter]
	[Event]
	[Log]
	void Counter(int counterValue, [Tag]int intParam, bool boolParam);
}
";

		// Act
		var generationResult = await GenerateAsync(basicTelemetry);

		// Assert
		await TestHelpers.Verify(
			generationResult,
			s => s.ScrubInlineGuids(),
			validateNonEmptyDiagnostics: true,
			validationCompilation: false
		);
	}
}
