using System.Collections.Immutable;
using Microsoft.CodeAnalysis;

namespace Purview.Telemetry.SourceGenerator.Records;

/// <summary>
/// Represents a method that uses multi-target telemetry generation.
/// </summary>
record MultiTargetMethod(
	string MethodName,
	string FullyQualifiedMethodName,
	IMethodSymbol MethodSymbol,
	MultiTargetConfiguration Configuration,
	ImmutableArray<MultiTargetParameter> Parameters,
	string ContainingTypeName,
	string Namespace,
	bool IsPartial,
	Location Location
);

/// <summary>
/// Represents a parameter in a multi-target method with exclusion information.
/// </summary>
record MultiTargetParameter(
	string Name,
	string TypeName,
	IParameterSymbol ParameterSymbol,
	ParameterExclusions Exclusions,
	bool IsTag,
	bool IsBaggage,
	string? TagName,
	string? BaggageName
);