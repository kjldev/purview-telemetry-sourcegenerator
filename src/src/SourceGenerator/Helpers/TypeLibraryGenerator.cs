namespace Purview.Telemetry.SourceGenerator.Helpers;

[GenerateTypeLibrary]
static partial class TypeLibraryGenerator
{
	const string PurviewTelemetryNamespace = "Purview.Telemetry";
	const string LoggingNamespace = "Microsoft.Extensions.Logging";
	const string SystemDiagnosticsNamespace = "System.Diagnostics";
	const string SystemDiagnosticsMetricsNamespace = "System.Diagnostics.Metrics";

	// Purview Telemetry types
	// Activities
	[TypeRef(PurviewTelemetryNamespace, IncludeInGetTypes = true)]
	static readonly TypeIdentity ActivitySourceGenerationAttribute = default;

	[TypeRef(PurviewTelemetryNamespace, IncludeInGetTypes = true)]
	static readonly TypeIdentity ActivitySourceAttribute = default;

	[TypeRef(PurviewTelemetryNamespace, IncludeInGetTypes = true)]
	static readonly TypeIdentity ActivityAttribute = default;

	[TypeRef(PurviewTelemetryNamespace, IncludeInGetTypes = true)]
	static readonly TypeIdentity EventAttribute = default;

	[TypeRef(PurviewTelemetryNamespace, IncludeInGetTypes = true)]
	static readonly TypeIdentity ContextAttribute = default;

	[TypeRef(PurviewTelemetryNamespace, IncludeInGetTypes = true)]
	static readonly TypeIdentity BaggageAttribute = default;

	[TypeRef(PurviewTelemetryNamespace, IncludeInGetTypes = true)]
	static readonly TypeIdentity EscapeAttribute = default;

	[TypeRef(PurviewTelemetryNamespace, IncludeInGetTypes = true)]
	static readonly TypeIdentity StatusDescriptionAttribute = default;

	// Logging
	[TypeRef(PurviewTelemetryNamespace, IncludeInGetTypes = true)]
	static readonly TypeIdentity LoggerGenerationAttribute = default;

	[TypeRef(PurviewTelemetryNamespace, IncludeInGetTypes = true)]
	static readonly TypeIdentity LoggerAttribute = default;

	[TypeRef(PurviewTelemetryNamespace, IncludeInGetTypes = true)]
	static readonly TypeIdentity LogAttribute = default;

	[TypeRef(PurviewTelemetryNamespace, IncludeInGetTypes = true)]
	static readonly TypeIdentity LogPrefixType = default;

	[TypeRef(PurviewTelemetryNamespace, IncludeInGetTypes = true)]
	static readonly TypeIdentity LoggerGenerationMode = default;

	[TypeRef(PurviewTelemetryNamespace, IncludeInGetTypes = true)]
	static readonly TypeIdentity ExpandEnumerableAttribute = default;

	[TypeRef(PurviewTelemetryNamespace, IncludeInGetTypes = true)]
	static readonly TypeIdentity TraceAttribute = default;

	[TypeRef(PurviewTelemetryNamespace, IncludeInGetTypes = true)]
	static readonly TypeIdentity DebugAttribute = default;

	[TypeRef(PurviewTelemetryNamespace, IncludeInGetTypes = true)]
	static readonly TypeIdentity InfoAttribute = default;

	[TypeRef(PurviewTelemetryNamespace, IncludeInGetTypes = true)]
	static readonly TypeIdentity WarningAttribute = default;

	[TypeRef(PurviewTelemetryNamespace, IncludeInGetTypes = true)]
	static readonly TypeIdentity ErrorAttribute = default;

	[TypeRef(PurviewTelemetryNamespace, IncludeInGetTypes = true)]
	static readonly TypeIdentity CriticalAttribute = default;

	// Metric
	[TypeRef(PurviewTelemetryNamespace, IncludeInGetTypes = true)]
	static readonly TypeIdentity MeterGenerationAttribute = default;

	[TypeRef(PurviewTelemetryNamespace, IncludeInGetTypes = true)]
	static readonly TypeIdentity MeterAttribute = default;

	[TypeRef(PurviewTelemetryNamespace, IncludeInGetTypes = true)]
	static readonly TypeIdentity MeterNameGenerationType = default;

	[TypeRef(PurviewTelemetryNamespace, IncludeInGetTypes = true)]
	static readonly TypeIdentity InstrumentMeasurementAttribute = default;

	[TypeRef(PurviewTelemetryNamespace, IncludeInGetTypes = true)]
	static readonly TypeIdentity AutoCounterAttribute = default;

	[TypeRef(PurviewTelemetryNamespace, IncludeInGetTypes = true)]
	static readonly TypeIdentity CounterAttribute = default;

	[TypeRef(PurviewTelemetryNamespace, IncludeInGetTypes = true)]
	static readonly TypeIdentity UpDownCounterAttribute = default;

	[TypeRef(PurviewTelemetryNamespace, IncludeInGetTypes = true)]
	static readonly TypeIdentity HistogramAttribute = default;

	[TypeRef(PurviewTelemetryNamespace, IncludeInGetTypes = true)]
	static readonly TypeIdentity ObservableCounterAttribute = default;

	[TypeRef(PurviewTelemetryNamespace, IncludeInGetTypes = true)]
	static readonly TypeIdentity ObservableUpDownCounterAttribute = default;

	[TypeRef(PurviewTelemetryNamespace, IncludeInGetTypes = true)]
	static readonly TypeIdentity ObservableGaugeAttribute = default;

	// Shared
	[TypeRef(PurviewTelemetryNamespace, IncludeInGetTypes = true)]
	static readonly TypeIdentity TagAttribute = default;

	[TypeRef(PurviewTelemetryNamespace, IncludeInGetTypes = true)]
	static readonly TypeIdentity ExcludeAttribute = default;

	[TypeRef(PurviewTelemetryNamespace, IncludeInGetTypes = true)]
	static readonly TypeIdentity TelemetryGenerationAttribute = default;

	[TypeRef(PurviewTelemetryNamespace, IncludeInGetTypes = true)]
	static readonly TypeIdentity Targets = default;

	[TypeRef(PurviewTelemetryNamespace, IncludeInGetTypes = true)]
	static readonly TypeIdentity NamingConvention = default;

	[TypeRef(PurviewTelemetryNamespace, IncludeInGetTypes = true)]
	static readonly TypeIdentity ExcludeTargetsAttribute = default;
}
