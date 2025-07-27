﻿using Microsoft.CodeAnalysis;
using Purview.Telemetry.SourceGenerator.Records;

namespace Purview.Telemetry.SourceGenerator;

partial class TelemetryDiagnostics
{
	// Starts at 4000
	public static class Metrics
	{
		public static readonly TelemetryDiagnosticDescriptor NoInstrumentDefined = new(
			Id: "TSG4000",
			Title: "No instrument defined",
			Description: "Either exclude this method, or define an instrument.",
			Category: Constants.Diagnostics.Metrics.Usage,
			Severity: DiagnosticSeverity.Error
		);

		public static readonly TelemetryDiagnosticDescriptor DoesNotReturnVoid = new(
			Id: "TSG4001",
			Title: "Must return void or bool",
			Description: "Instrument methods can only return void or boolean.",
			Category: Constants.Diagnostics.Metrics.Usage,
			Severity: DiagnosticSeverity.Error
		);

		public static readonly TelemetryDiagnosticDescriptor AutoIncrementCountAndMeasurementParam =
			new(
				Id: "TSG4002",
				Title: "Auto increment counter and measurement defined",
				Description: "Auto increment counter and a measurement parameter are defined, either remove the parameter/ attribute or change to a normal counter.",
				Category: Constants.Diagnostics.Metrics.Usage,
				Severity: DiagnosticSeverity.Error
			);

		public static readonly TelemetryDiagnosticDescriptor MoreThanOneMeasurementValueDefined =
			new(
				Id: "TSG4003",
				Title: "Multiple measurement values defined",
				Description: "More than one measurement parameters are defined.",
				Category: Constants.Diagnostics.Metrics.Usage,
				Severity: DiagnosticSeverity.Error
			);

		public static readonly TelemetryDiagnosticDescriptor NoMeasurementValueDefined = new(
			Id: "TSG4004",
			Title: "No measurement value defined",
			Description: "Either define a measurement parameter, or provide a supported type parameter that is not a tag to enable inferring.",
			Category: Constants.Diagnostics.Metrics.Usage,
			Severity: DiagnosticSeverity.Error
		);

		public static readonly TelemetryDiagnosticDescriptor ObservableRequiredFunc = new(
			Id: "TSG4005",
			Title: "Observable instrument requires Func<T>",
			Description: "Observable instruments require a Func<T> where T is a supported instrument result type.",
			Category: Constants.Diagnostics.Metrics.Usage,
			Severity: DiagnosticSeverity.Error
		);

		public static readonly TelemetryDiagnosticDescriptor InvalidMeasurementType = new(
			Id: "TSG4006",
			Title: "Invalid measurement type",
			Description: $"Invalid measurement type used, valid types are {string.Join(", ", Constants.Metrics.ValidMeasurementKeywordTypes)}, Measurement<T> or IEnumerable<MeasurementT>>.",
			Category: Constants.Diagnostics.Metrics.Usage,
			Severity: DiagnosticSeverity.Error
		);
	}
}
