using Microsoft.CodeAnalysis;
using Purview.Telemetry.SourceGenerator.Records;

namespace Purview.Telemetry.SourceGenerator.Helpers;

partial class SharedHelpers
{
	public static MeterGenerationAttributeRecord? GetMeterGenerationAttribute(
		SemanticModel semanticModel,
		GenerationLogger? logger,
		CancellationToken token
	) =>
		GetMeterGenerationAttribute(
			semanticModel.Compilation.Assembly,
			semanticModel,
			logger,
			token
		);

	public static MeterAttributeRecord? GetMeterAttribute(
		ISymbol symbol,
		SemanticModel semanticModel,
		GenerationLogger? logger,
		CancellationToken token
	)
	{
		if (
			!Utilities.TryContainsAttribute(
				symbol,
				Constants.Metrics.MeterAttribute,
				token,
				out var attributeData
			)
		)
			return null;

		AttributeStringValue? nameValue = null;
		AttributeStringValue? instrumentPrefix = null;
		AttributeValue<bool>? includeAssemblyInstrumentPrefix = null;
		AttributeValue<bool>? lowercaseInstrumentName = null;
		AttributeValue<bool>? lowercaseTagKeys = null;

		if (
			!AttributeParser(
				attributeData!,
				(name, value) =>
				{
					if (
						name.Equals(
							nameof(MeterAttributeRecord.Name),
							StringComparison.OrdinalIgnoreCase
						)
					)
						nameValue = new((string)value);
					else if (
						name.Equals(
							nameof(MeterAttributeRecord.InstrumentPrefix),
							StringComparison.OrdinalIgnoreCase
						)
					)
						instrumentPrefix = new((string)value);
					else if (
						name.Equals(
							nameof(MeterAttributeRecord.IncludeAssemblyInstrumentPrefix),
							StringComparison.OrdinalIgnoreCase
						)
					)
						includeAssemblyInstrumentPrefix = new((bool)value);
					else if (
						name.Equals(
							nameof(MeterAttributeRecord.LowercaseInstrumentName),
							StringComparison.OrdinalIgnoreCase
						)
					)
						lowercaseInstrumentName = new((bool)value);
					else if (
						name.Equals(
							nameof(MeterAttributeRecord.LowercaseTagKeys),
							StringComparison.OrdinalIgnoreCase
						)
					)
						lowercaseTagKeys = new((bool)value);
				},
				semanticModel,
				logger,
				token
			)
		)
		{
			// Failed to parse correctly, so null it out.
			return null;
		}

		return new(
			Name: nameValue ?? new(),
			InstrumentPrefix: instrumentPrefix ?? new(),
			IncludeAssemblyInstrumentPrefix: includeAssemblyInstrumentPrefix ?? new(true),
			LowercaseInstrumentName: lowercaseInstrumentName
				?? new(Constants.Metrics.LowercaseInstrumentNameDefault),
			LowercaseTagKeys: lowercaseTagKeys ?? new(Constants.Metrics.LowercaseTagKeysDefault)
		);
	}

	public static MeterGenerationAttributeRecord? GetMeterGenerationAttribute(
		ISymbol symbol,
		SemanticModel semanticModel,
		GenerationLogger? logger,
		CancellationToken token
	)
	{
		if (
			!Utilities.TryContainsAttribute(
				symbol,
				Constants.Metrics.MeterGenerationAttribute,
				token,
				out var attributeData
			)
		)
			return null;

		AttributeStringValue? instrumentPrefix = null;
		AttributeStringValue? instrumentSeparator = null;
		AttributeValue<bool>? lowercaseInstrumentName = null;
		AttributeValue<bool>? lowercaseTagKeys = null;

		if (
			!AttributeParser(
				attributeData!,
				(name, value) =>
				{
					if (
						name.Equals(
							nameof(MeterGenerationAttributeRecord.InstrumentPrefix),
							StringComparison.OrdinalIgnoreCase
						)
					)
						instrumentPrefix = new((string)value);
					else if (
						name.Equals(
							nameof(MeterGenerationAttributeRecord.InstrumentSeparator),
							StringComparison.OrdinalIgnoreCase
						)
					)
						instrumentSeparator = new((string)value);
					else if (
						name.Equals(
							nameof(MeterGenerationAttributeRecord.LowercaseInstrumentName),
							StringComparison.OrdinalIgnoreCase
						)
					)
						lowercaseInstrumentName = new((bool)value);
					else if (
						name.Equals(
							nameof(MeterGenerationAttributeRecord.LowercaseTagKeys),
							StringComparison.OrdinalIgnoreCase
						)
					)
						lowercaseTagKeys = new((bool)value);
				},
				semanticModel,
				logger,
				token
			)
		)
		{
			// Failed to parse correctly, so null it out.
			return null;
		}

		return new(
			InstrumentPrefix: instrumentPrefix ?? new(),
			InstrumentSeparator: instrumentSeparator
				?? new(Constants.Metrics.InstrumentSeparatorDefault),
			LowercaseInstrumentName: lowercaseInstrumentName
				?? new(Constants.Metrics.LowercaseInstrumentNameDefault),
			LowercaseTagKeys: lowercaseTagKeys ?? new(Constants.Metrics.LowercaseTagKeysDefault)
		);
	}

	public static InstrumentAttributeRecord? GetInstrumentAttribute(
		ISymbol symbol,
		SemanticModel semanticModel,
		GenerationLogger? logger,
		CancellationToken token
	)
	{
		AttributeData? attributeData = null;
		foreach (var instrumentAttribute in Constants.Metrics.ValidInstrumentAttributes)
		{
			if (
				Utilities.TryContainsAttribute(
					symbol,
					instrumentAttribute,
					token,
					out attributeData
				)
			)
				break;
		}

		if (attributeData?.AttributeClass == null)
			return null;

		AttributeStringValue? nameValue = null;
		AttributeStringValue? unit = null;
		AttributeStringValue? description = null;
		AttributeValue<bool>? autoIncrement = null;
		AttributeValue<bool>? throwOnAlreadyInitialized = null;

		if (
			!AttributeParser(
				attributeData,
				(name, value) =>
				{
					if (
						name.Equals(
							nameof(InstrumentAttributeRecord.Name),
							StringComparison.OrdinalIgnoreCase
						)
					)
						nameValue = new((string)value);
					else if (
						name.Equals(
							nameof(InstrumentAttributeRecord.Unit),
							StringComparison.OrdinalIgnoreCase
						)
					)
						unit = new((string)value);
					else if (
						name.Equals(
							nameof(InstrumentAttributeRecord.Description),
							StringComparison.OrdinalIgnoreCase
						)
					)
						description = new((string)value);
					else if (
						name.Equals(
							nameof(InstrumentAttributeRecord.AutoIncrement),
							StringComparison.OrdinalIgnoreCase
						)
					)
						autoIncrement = new((bool)value);
					else if (
						name.Equals(
							nameof(InstrumentAttributeRecord.ThrowOnAlreadyInitialized),
							StringComparison.OrdinalIgnoreCase
						)
					)
						throwOnAlreadyInitialized = new((bool)value);
				},
				semanticModel,
				logger,
				token
			)
		)
		{
			// Failed to parse correctly, so null it out.
			return null;
		}

		InstrumentTypes instrumentType;
		var isAutoCounter = Constants.Metrics.AutoCounterAttribute.Equals(
			attributeData.AttributeClass
		);
		if (
			isAutoCounter || Constants.Metrics.CounterAttribute.Equals(attributeData.AttributeClass)
		)
		{
			instrumentType = InstrumentTypes.Counter;

			if (isAutoCounter)
				autoIncrement = new(true);
		}
		else if (Constants.Metrics.HistogramAttribute.Equals(attributeData.AttributeClass))
			instrumentType = InstrumentTypes.Histogram;
		else if (Constants.Metrics.UpDownCounterAttribute.Equals(attributeData.AttributeClass))
			instrumentType = InstrumentTypes.UpDownCounter;
		else if (Constants.Metrics.ObservableCounterAttribute.Equals(attributeData.AttributeClass))
			instrumentType = InstrumentTypes.ObservableCounter;
		else if (
			Constants.Metrics.ObservableUpDownCounterAttribute.Equals(attributeData.AttributeClass)
		)
			instrumentType = InstrumentTypes.ObservableUpDownCounter;
		else if (Constants.Metrics.ObservableGaugeAttribute.Equals(attributeData.AttributeClass))
			instrumentType = InstrumentTypes.ObservableGauge;
		else
		{
			logger?.Error($"Unknown instrument type {attributeData.AttributeClass}.");
			return null;
		}

		return new(
			Name: nameValue ?? new(),
			Unit: unit ?? new(),
			Description: description ?? new(),
			AutoIncrement: autoIncrement ?? new(),
			ThrowOnAlreadyInitialized: throwOnAlreadyInitialized ?? new(),
			InstrumentType: instrumentType
		);
	}

	public static bool IsValidMeasurementValueType(ITypeSymbol type) =>
		Array.FindIndex(
			Constants.Metrics.ValidMeasurementKeywordTypes,
			m => m == type.ToDisplayString()
		) > -1
		|| Array.FindIndex(Constants.Metrics.ValidMeasurementTypes, m => m.Equals(type)) > -1;

	public static bool IsInstrument(IMethodSymbol method, CancellationToken token)
	{
		foreach (var instrumentAttribute in Constants.Metrics.ValidInstrumentAttributes)
		{
			if (Utilities.TryContainsAttribute(method, instrumentAttribute, token, out _))
				return true;
		}

		return false;
	}
}
