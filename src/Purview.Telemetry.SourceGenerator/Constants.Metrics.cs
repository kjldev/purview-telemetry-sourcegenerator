﻿using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
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
			System.BuiltInTypes.ByteKeyword,
			System.BuiltInTypes.ShortKeyword,
			System.BuiltInTypes.IntKeyword,
			System.BuiltInTypes.LongKeyword,
			System.BuiltInTypes.DoubleKeyword,
			System.BuiltInTypes.FloatKeyword,
			System.BuiltInTypes.DecimalKeyword,
		];

		public static readonly SpecialType[] ValidMeasurementSpecialTypes =
		[
			SpecialType.System_Byte,
			SpecialType.System_Int16,
			SpecialType.System_Int32,
			SpecialType.System_Int64,
			SpecialType.System_Double,
			SpecialType.System_Single,
			SpecialType.System_Decimal,
		];

		public static readonly ImmutableDictionary<
			InstrumentTypes,
			PurviewTypeInfo
		> InstrumentTypeMap = new Dictionary<InstrumentTypes, PurviewTypeInfo>
		{
			{ InstrumentTypes.Counter, SystemDiagnostics.Counter },
			{ InstrumentTypes.UpDownCounter, SystemDiagnostics.UpDownCounter },
			{ InstrumentTypes.Histogram, SystemDiagnostics.Histogram },
			{ InstrumentTypes.ObservableCounter, SystemDiagnostics.ObservableCounter },
			{ InstrumentTypes.ObservableGauge, SystemDiagnostics.ObservableGauge },
			{ InstrumentTypes.ObservableUpDownCounter, SystemDiagnostics.ObservableUpDownCounter },
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

			public static readonly PurviewTypeInfo Meter = PurviewTypeFactory.Create(
				SystemDiagnosticsMetricsNamespace + ".Meter"
			);
			public static readonly PurviewTypeInfo IMeterFactory = PurviewTypeFactory.Create(
				SystemDiagnosticsMetricsNamespace + ".IMeterFactory"
			);
			public static readonly PurviewTypeInfo MeterOptions = PurviewTypeFactory.Create(
				SystemDiagnosticsMetricsNamespace + ".MeterOptions"
			);

			public static readonly PurviewTypeInfo Counter = PurviewTypeFactory.Create(
				SystemDiagnosticsMetricsNamespace + ".Counter"
			); // <>
			public static readonly PurviewTypeInfo UpDownCounter = PurviewTypeFactory.Create(
				SystemDiagnosticsMetricsNamespace + ".UpDownCounter"
			); // <>
			public static readonly PurviewTypeInfo Histogram = PurviewTypeFactory.Create(
				SystemDiagnosticsMetricsNamespace + ".Histogram"
			); // <>

			public static readonly PurviewTypeInfo ObservableCounter = PurviewTypeFactory.Create(
				SystemDiagnosticsMetricsNamespace + "." + ObservableCounterNoun
			); // <>
			public static readonly PurviewTypeInfo ObservableGauge = PurviewTypeFactory.Create(
				SystemDiagnosticsMetricsNamespace + "." + ObservableGaugeNoun
			); // <>
			public static readonly PurviewTypeInfo ObservableUpDownCounter =
				PurviewTypeFactory.Create(
					SystemDiagnosticsMetricsNamespace + "." + ObservableUpDownCounterNoun
				); // <>

			// Also supports IEnumerable<Measurement>.
			public static readonly PurviewTypeInfo Measurement = PurviewTypeFactory.Create(
				SystemDiagnosticsMetricsNamespace + ".Measurement"
			); // <>
		}
	}
}
