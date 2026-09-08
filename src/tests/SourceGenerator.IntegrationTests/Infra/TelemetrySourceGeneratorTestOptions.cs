using System.Diagnostics;
using System.Diagnostics.Metrics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Purview.Telemetry.SourceGenerator.Analyzers;

namespace Purview.Telemetry.SourceGenerator.Infra;

public sealed record TelemetrySourceGeneratorTestOptions : SourceGeneratorTestOptions
{
	public TelemetrySourceGeneratorTestOptions()
	{
		AdditionalNamespaces = ["Purview.Telemetry"];

		AdditionalAssemblyTypes =
		[
			typeof(Activity),
			typeof(Meter),
			typeof(IServiceCollection),
			typeof(LogLevel),
			typeof(LogPropertiesAttribute),
		];

		AnalyzerTypes = [typeof(TelemetryDiagnosticAnalyzer)];

		// Undisposed CodeWriter scopes fail tests, so emitters must dispose every scope they open.
		ValidateCodeWriterScopes = true;

		// Most tests do not want a dependency-injection extension generated.
		AdditionalSources = ["[assembly: Purview.Telemetry.TelemetryGeneration(GenerateDependencyExtension = false)]"];

		ExcludeGeneratedSourceHintNames =
		[
			TypeLibrary.Microsoft.CodeAnalysis.EmbeddedAttribute,
			.. TypeLibrary.Purview.Telemetry.GetTypes().Select(c => c.Identity.MetadataFullName),
		];
	}

	/// <summary>
	/// Disables the framework's automatic <see cref="DriverRunResult.EnsureValid"/> check.
	/// Pass to <c>GenerateAsync</c> for tests that intentionally produce compilation errors
	/// (invalid return types, duplicate method names, etc.). All other tests keep validation on.
	/// </summary>
	public static readonly TelemetrySourceGeneratorTestOptions NoValidation = new()
	{
		ThrowOnGenerationException = false,
	};

	public static new TelemetrySourceGeneratorTestOptions Default => new();
}
