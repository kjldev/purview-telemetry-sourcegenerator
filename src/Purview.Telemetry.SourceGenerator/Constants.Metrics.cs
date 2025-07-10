using System.Collections.Immutable;
using Purview.Telemetry.SourceGenerator.Records;
using Purview.Telemetry.SourceGenerator.Templates;

namespace Purview.Telemetry;

partial class Constants
{
	public static class Metrics
	{
		public const string MeterInitializationMethod = "InitializeMeters";
		public const string MeterFactoryParameterName = "meterFactory";

		public const string InstrumentSeparatorDefault = ".";
		public const bool LowercaseInstrumentNameDefault = true;
		public const bool LowercaseTagKeysDefault = true;

		public static readonly TemplateInfo MeterGenerationAttribute = TemplateInfo.Create(
			"Purview.Telemetry.Metrics.MeterGenerationAttribute"
		);
		public static readonly TemplateInfo MeterAttribute = TemplateInfo.Create(
			"Purview.Telemetry.Metrics.MeterAttribute"
		);

		public static readonly TemplateInfo InstrumentMeasurementAttribute = TemplateInfo.Create(
			"Purview.Telemetry.Metrics.InstrumentMeasurementAttribute"
		);

		public static readonly TemplateInfo AutoCounterAttribute = TemplateInfo.Create(
			"Purview.Telemetry.Metrics.AutoCounterAttribute"
		);
		public static readonly TemplateInfo CounterAttribute = TemplateInfo.Create(
			"Purview.Telemetry.Metrics.CounterAttribute"
		);
		public static readonly TemplateInfo UpDownCounterAttribute = TemplateInfo.Create(
			"Purview.Telemetry.Metrics.UpDownCounterAttribute"
		);
		public static readonly TemplateInfo HistogramAttribute = TemplateInfo.Create(
			"Purview.Telemetry.Metrics.HistogramAttribute"
		);

		public static readonly TemplateInfo ObservableCounterAttribute = TemplateInfo.Create(
			"Purview.Telemetry.Metrics.ObservableCounterAttribute"
		);
		public static readonly TemplateInfo ObservableUpDownCounterAttribute = TemplateInfo.Create(
			"Purview.Telemetry.Metrics.ObservableUpDownCounterAttribute"
		);
		public static readonly TemplateInfo ObservableGaugeAttribute = TemplateInfo.Create(
			"Purview.Telemetry.Metrics.ObservableGaugeAttribute"
		);

		public static readonly TemplateInfo[] ValidInstrumentAttributes =
		[
			AutoCounterAttribute,
			CounterAttribute,
			UpDownCounterAttribute,
			HistogramAttribute,
			ObservableCounterAttribute,
			ObservableUpDownCounterAttribute,
			ObservableGaugeAttribute,
		];

		public static readonly string[] ValidMeasurementKeywordTypes =
		[
			System.ByteKeyword,
			System.ShortKeyword,
			System.IntKeyword,
			System.LongKeyword,
			System.DoubleKeyword,
			System.FloatKeyword,
			System.DecimalKeyword,
		];

		public static readonly TypeInfo[] ValidMeasurementTypes =
		[
			System.Byte,
			System.Int16,
			System.Int32,
			System.Int64,
			System.Double,
			System.Single,
			System.Decimal,
		];

		public static readonly ImmutableDictionary<InstrumentTypes, TypeInfo> InstrumentTypeMap =
			new Dictionary<InstrumentTypes, TypeInfo>
			{
				{ InstrumentTypes.Counter, SystemDiagnostics.Counter },
				{ InstrumentTypes.UpDownCounter, SystemDiagnostics.UpDownCounter },
				{ InstrumentTypes.Histogram, SystemDiagnostics.Histogram },
				{ InstrumentTypes.ObservableCounter, SystemDiagnostics.ObservableCounter },
				{ InstrumentTypes.ObservableGauge, SystemDiagnostics.ObservableGauge },
				{
					InstrumentTypes.ObservableUpDownCounter,
					SystemDiagnostics.ObservableUpDownCounter
				},
			}.ToImmutableDictionary();

		public static TemplateInfo[] GetTemplates() =>
			[
				MeterGenerationAttribute,
				MeterAttribute,
				InstrumentMeasurementAttribute,
				AutoCounterAttribute,
				CounterAttribute,
				UpDownCounterAttribute,
				HistogramAttribute,
				ObservableCounterAttribute,
				ObservableGaugeAttribute,
				ObservableUpDownCounterAttribute,
			];

		public static class SystemDiagnostics
		{
			public const string ObservableCounterNoun = "ObservableCounter";
			public const string ObservableGaugeNoun = "ObservableGauge";
			public const string ObservableUpDownCounterNoun = "ObservableUpDownCounter";

			const string SystemDiagnosticsMetricsNamespace =
				SystemDiagnosticsNamespace + ".Metrics";

			public static readonly TypeInfo Meter = TypeInfo.Create(
				SystemDiagnosticsMetricsNamespace + ".Meter"
			);
			public static readonly TypeInfo IMeterFactory = TypeInfo.Create(
				SystemDiagnosticsMetricsNamespace + ".IMeterFactory"
			);
			public static readonly TypeInfo MeterOptions = TypeInfo.Create(
				SystemDiagnosticsMetricsNamespace + ".MeterOptions"
			);

			public static readonly TypeInfo Counter = TypeInfo.Create(
				SystemDiagnosticsMetricsNamespace + ".Counter"
			); // <>
			public static readonly TypeInfo UpDownCounter = TypeInfo.Create(
				SystemDiagnosticsMetricsNamespace + ".UpDownCounter"
			); // <>
			public static readonly TypeInfo Histogram = TypeInfo.Create(
				SystemDiagnosticsMetricsNamespace + ".Histogram"
			); // <>

			public static readonly TypeInfo ObservableCounter = TypeInfo.Create(
				SystemDiagnosticsMetricsNamespace + "." + ObservableCounterNoun
			); // <>
			public static readonly TypeInfo ObservableGauge = TypeInfo.Create(
				SystemDiagnosticsMetricsNamespace + "." + ObservableGaugeNoun
			); // <>
			public static readonly TypeInfo ObservableUpDownCounter = TypeInfo.Create(
				SystemDiagnosticsMetricsNamespace + "." + ObservableUpDownCounterNoun
			); // <>

			// Also supports IEnumerable<Measurement>.
			public static readonly TypeInfo Measurement = TypeInfo.Create(
				SystemDiagnosticsMetricsNamespace + ".Measurement"
			); // <>
		}
	}
}
