﻿using Microsoft.CodeAnalysis;
using Purview.Telemetry.SourceGenerator.Records;

namespace Purview.Telemetry.SourceGenerator;

partial class TelemetryDiagnostics
{
	// Start at 2000
	public static class Logging
	{
		public static readonly TelemetryDiagnosticDescriptor MultipleExceptionsDefined = new(
			Id: "TSG2000",
			Title: "Too many exception parameters",
			Description: "Only a single exceptions parameter is permitted.",
			Category: Constants.Diagnostics.Logging.Usage,
			Severity: DiagnosticSeverity.Error
		);

		public static readonly TelemetryDiagnosticDescriptor MaximumLogEntryParametersExceeded =
			new(
				Id: "TSG2001",
				Title: "More than 6 parameters",
				Description: $"The maximum number of parameters (excluding optional Exception) is {Constants.Logging.MaxNonExceptionParameters}",
				Category: Constants.Diagnostics.Logging.Usage,
				Severity: DiagnosticSeverity.Error
			);

		public static readonly TelemetryDiagnosticDescriptor InferringErrorLogLevel = new(
			Id: "TSG2002",
			Title: "Inferring error log level",
			Description: "Because an exception parameter was defined and no log level was defined the level was inferred to be Error. Consider explicitly defining the required level.",
			Category: Constants.Diagnostics.Logging.Usage,
			Severity: DiagnosticSeverity.Info
		);

		public static readonly TelemetryDiagnosticDescriptor MSLoggingNotReferenced = new(
			Id: "TSG2003",
			Title: "Could not find a reference to Microsoft.Extensions.Logging.ILogger, skipping log generation",
			Description: "No reference was found for the ILogger type, no log generation is possible so no logging attributes will be added. Add a reference to the appropriate NuGet package, such as Microsoft.Extensions.Logging.",
			Category: Constants.Diagnostics.Logging.Usage,
			Severity: DiagnosticSeverity.Warning
		);

		public static readonly TelemetryDiagnosticDescriptor MixedOrdinalAndNamedProperties = new(
			Id: "TSG2004",
			Title: "Cannot mix ordinal and named property placeholders",
			Description: "The message template for log method '{0}' mixes ordinal and named property placeholders which is not supported.",
			Category: Constants.Diagnostics.Logging.Usage,
			Severity: DiagnosticSeverity.Error
		);

		public static readonly TelemetryDiagnosticDescriptor OrdinalsExceedParameters = new(
			Id: "TSG2005",
			Title: "Ordinal values exceed parameter count",
			Description: "The maximum ordinal value for log method '{0}' exceeds the number of provided parameters.",
			Category: Constants.Diagnostics.Logging.Usage,
			Severity: DiagnosticSeverity.Error
		);

		public static readonly TelemetryDiagnosticDescriptor ExpandEnumerableAndLogPropertiesNotSupported =
			new(
				Id: "TSG2006",
				Title: "Using LogPropertiesAttribute and ExpandEnumerableAttribute on the same parameter is not supported",
				Description: "Expanding an array/ IEnumerable, and the expanding the complex type of the items in the array are not supported.",
				Category: Constants.Diagnostics.Logging.Usage,
				Severity: DiagnosticSeverity.Error
			);

		public static readonly TelemetryDiagnosticDescriptor ScopedMethodShouldNotHaveLevel = new(
			Id: "TSG2007",
			Title: "A scoped log shouldn't have a LogLevel, this will be ignored.",
			Description: "Scoped log entries do not support having a log level set.",
			Category: Constants.Diagnostics.Logging.Usage,
			Severity: DiagnosticSeverity.Warning
		);

		public static readonly TelemetryDiagnosticDescriptor UnboundedIEnumerableMaxCount = new(
			Id: "TSG2008",
			Title: "Unbounded enumeration possible",
			Description: $"The limit on unbounded enumeration is higher than the recommended default ({Constants.Logging.UnboundedIEnumerableMaxCountBeforeDiagnostic}). This may cause performance issues, make sure you understand the consequences and test thoroughly.",
			Category: Constants.Diagnostics.Logging.Performance,
			Severity: DiagnosticSeverity.Warning
		);
	}
}
