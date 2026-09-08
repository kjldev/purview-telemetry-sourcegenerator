using System.Collections.Immutable;
using Purview.Telemetry.SourceGenerator.Records;

namespace Purview.SourceGeneratorFramework;

static class TypeLibraryExtensions
{
	static readonly ImmutableArray<TypeIdentity> LogAttributeTargets = ImmutableArray.Create(
		TypeLibrary.Purview.Telemetry.LogAttribute,
		TypeLibrary.Purview.Telemetry.TraceAttribute,
		TypeLibrary.Purview.Telemetry.DebugAttribute,
		TypeLibrary.Purview.Telemetry.InfoAttribute,
		TypeLibrary.Purview.Telemetry.WarningAttribute,
		TypeLibrary.Purview.Telemetry.ErrorAttribute,
		TypeLibrary.Purview.Telemetry.CriticalAttribute
	);

	static readonly ImmutableDictionary<InstrumentTypes, TypeIdentity> InstrumentTypeMap = Create();

	static readonly ImmutableDictionary<TypeIdentity, LogLevelDetails> LogLevelMap = new Dictionary<
		TypeIdentity,
		LogLevelDetails
	>
	{
		{ TypeLibrary.Purview.Telemetry.TraceAttribute, new(TypeLibrary.Purview.Telemetry.TraceAttribute, 0, "Trace") },
		{ TypeLibrary.Purview.Telemetry.DebugAttribute, new(TypeLibrary.Purview.Telemetry.DebugAttribute, 1, "Debug") },
		{ TypeLibrary.Purview.Telemetry.InfoAttribute, new(TypeLibrary.Purview.Telemetry.InfoAttribute, 2, "Info") },
		{
			TypeLibrary.Purview.Telemetry.WarningAttribute,
			new(TypeLibrary.Purview.Telemetry.WarningAttribute, 3, "Warning")
		},
		{ TypeLibrary.Purview.Telemetry.ErrorAttribute, new(TypeLibrary.Purview.Telemetry.ErrorAttribute, 4, "Error") },
		{
			TypeLibrary.Purview.Telemetry.CriticalAttribute,
			new(TypeLibrary.Purview.Telemetry.CriticalAttribute, 5, "Critical")
		},
	}.ToImmutableDictionary();

	static ImmutableDictionary<InstrumentTypes, TypeIdentity> Create() =>
		new Dictionary<InstrumentTypes, TypeIdentity>
		{
			{ InstrumentTypes.Counter, TypeLibrary.System.Diagnostics.Metrics.Counter },
			{ InstrumentTypes.UpDownCounter, TypeLibrary.System.Diagnostics.Metrics.UpDownCounter },
			{ InstrumentTypes.Histogram, TypeLibrary.System.Diagnostics.Metrics.Histogram },
			{ InstrumentTypes.ObservableCounter, TypeLibrary.System.Diagnostics.Metrics.ObservableCounter },
			{ InstrumentTypes.ObservableGauge, TypeLibrary.System.Diagnostics.Metrics.ObservableGauge },
			{ InstrumentTypes.ObservableUpDownCounter, TypeLibrary.System.Diagnostics.Metrics.ObservableUpDownCounter },
		}.ToImmutableDictionary();

	extension(TypeLibrary.Purview.Telemetry)
	{
		public static ImmutableArray<TypeIdentity> LogAttributeTargets => LogAttributeTargets;

		public static ImmutableDictionary<TypeIdentity, LogLevelDetails> LogLevelMap => LogLevelMap;

		public static ImmutableDictionary<InstrumentTypes, TypeIdentity> InstrumentTypeMap => InstrumentTypeMap;
	}
}
