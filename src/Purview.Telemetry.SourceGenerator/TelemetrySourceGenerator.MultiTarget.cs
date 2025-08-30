/*
// TODO: Re-enable after implementing complete multi-target functionality

using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Purview.Telemetry.SourceGenerator.Emitters;
using Purview.Telemetry.SourceGenerator.Helpers;
using Purview.Telemetry.SourceGenerator.Records;
using Purview.Telemetry.SourceGenerator.Templates;

namespace Purview.Telemetry.SourceGenerator;

partial class TelemetrySourceGenerator
{
	static void RegisterMultiTargetGeneration(
		IncrementalGeneratorInitializationContext context,
		GenerationLogger? logger
	)
	{
		// Transform for multi-target methods
		Func<
			GeneratorAttributeSyntaxContext,
			CancellationToken,
			MultiTargetMethod?
		> multiTargetTransform =
			logger == null
				? static (context, cancellationToken) =>
					PipelineHelpers.BuildMultiTargetTransform(context, null, cancellationToken)
				: (context, cancellationToken) =>
					PipelineHelpers.BuildMultiTargetTransform(context, logger, cancellationToken);

		// Register for methods with MultiTargetTelemetryAttribute
		var multiTargetMethodsPredicate = context
			.SyntaxProvider.ForAttributeWithMetadataName(
				Constants.Shared.MultiTargetTelemetryAttribute.TypeInfo.FullyQualifiedName,
				static (node, token) => PipelineHelpers.HasMultiTargetAttribute(node, token),
				multiTargetTransform
			)
			.WhereNotNull()
			.WithTrackingName($"{nameof(TelemetrySourceGenerator)}_MultiTarget");

		// Build generation action
		Action<
			SourceProductionContext,
			(Compilation Compilation, ImmutableArray<MultiTargetMethod?> Methods)
		> generationMultiTargetAction =
			logger == null
				? static (spc, source) => GenerateMultiTargetMethods(source.Methods, spc, null)
				: (spc, source) => GenerateMultiTargetMethods(source.Methods, spc, logger);

		// Register with the source generator
		var multiTargetMethods = context.CompilationProvider.Combine(
			multiTargetMethodsPredicate.Collect()
		);

		context.RegisterImplementationSourceOutput(
			multiTargetMethods,
			generationMultiTargetAction
		);
	}

	static void GenerateMultiTargetMethods(
		ImmutableArray<MultiTargetMethod?> methods,
		SourceProductionContext context,
		GenerationLogger? logger
	)
	{
		var filteredMethods = methods.Where(m => m != null).Cast<MultiTargetMethod>().ToArray();

		if (filteredMethods.Length == 0)
			return;

		foreach (var method in filteredMethods)
		{
			try
			{
				GenerateMultiTargetMethod(method, context, logger);
			}
			catch (Exception ex)
			{
				logger?.Error($"Error generating multi-target method {method.MethodName}: {ex.Message}");
				TelemetryDiagnostics.Report(
					context.ReportDiagnostic,
					TelemetryDiagnostics.General.FatalExecutionDuringExecution,
					ex
				);
			}
		}
	}

	static void GenerateMultiTargetMethod(
		MultiTargetMethod method,
		SourceProductionContext context,
		GenerationLogger? logger
	)
	{
		logger?.Debug($"Generating multi-target method: {method.MethodName}");

		// Generate for each enabled target type
		if (method.Configuration.TargetTypes.HasFlag(GenerationType.Activities))
		{
			// Generate Activity target
			GenerateActivityFromMultiTarget(method, context, logger);
		}

		if (method.Configuration.TargetTypes.HasFlag(GenerationType.Logging))
		{
			// Generate Logging target
			GenerateLoggingFromMultiTarget(method, context, logger);
		}

		if (method.Configuration.TargetTypes.HasFlag(GenerationType.Metrics))
		{
			// Generate Metrics target
			GenerateMetricsFromMultiTarget(method, context, logger);
		}
	}

	static void GenerateActivityFromMultiTarget(
		MultiTargetMethod method,
		SourceProductionContext context,
		GenerationLogger? logger
	)
	{
		// TODO: Implement Activity generation from multi-target method
		logger?.Debug($"Generating Activity for multi-target method: {method.MethodName}");
	}

	static void GenerateLoggingFromMultiTarget(
		MultiTargetMethod method,
		SourceProductionContext context,
		GenerationLogger? logger
	)
	{
		// TODO: Implement Logging generation from multi-target method
		logger?.Debug($"Generating Logging for multi-target method: {method.MethodName}");
	}

	static void GenerateMetricsFromMultiTarget(
		MultiTargetMethod method,
		SourceProductionContext context,
		GenerationLogger? logger
	)
	{
		// TODO: Implement Metrics generation from multi-target method
		logger?.Debug($"Generating Metrics for multi-target method: {method.MethodName}");
	}
}
*/