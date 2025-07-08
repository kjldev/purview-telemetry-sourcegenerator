﻿using System.Text;
using Microsoft.CodeAnalysis;
using Purview.Telemetry.SourceGenerator.Helpers;
using Purview.Telemetry.SourceGenerator.Records;
using Purview.Telemetry.SourceGenerator.Templates;

namespace Purview.Telemetry.SourceGenerator.Emitters;

static partial class LoggerGenTargetClassEmitter
{
	public static void GenerateImplementation(
		LoggerTarget target,
		SourceProductionContext context,
		GenerationLogger? logger
	)
	{
		StringBuilder builder = new();

		logger?.Debug($"Generating MS Gen-based logging class for: {target.FullyQualifiedName}");

		if (
			EmitHelpers.GenerateDuplicateMethodDiagnostics(
				GenerationType.Logging,
				target.GenerationType,
				target.DuplicateMethods,
				context,
				logger
			)
		)
		{
			logger?.Debug("Found duplicate methods while generating logger, exiting.");
			return;
		}

		var indent = EmitHelpers.EmitNamespaceStart(
			target.ClassNamespace,
			target.ParentClasses,
			builder,
			context.CancellationToken
		);
		indent = EmitHelpers.EmitClassStart(
			GenerationType.Logging,
			target.GenerationType,
			target.ClassNameToGenerate,
			target.FullyQualifiedInterfaceName,
			builder,
			indent,
			context.CancellationToken
		);

		EmitFields(target, builder, indent, context);

		indent = ConstructorEmitter.EmitCtor(
			GenerationType.Logging,
			target.GenerationType,
			target.ClassNameToGenerate,
			target.FullyQualifiedInterfaceName,
			builder,
			indent,
			context,
			logger
		);

		indent = EmitMethods(target, builder, indent, context, logger);

		EmitHelpers.EmitClassEnd(builder, indent);
		EmitHelpers.EmitNamespaceEnd(
			target.ClassNamespace,
			target.ParentClasses,
			indent,
			builder,
			context.CancellationToken
		);

		var sourceText = EmbeddedResources.Instance.AddHeader(builder.ToString());
		var hintName = $"{target.FullyQualifiedName}.Logging.g.cs";

		context.AddSource(
			hintName,
			Microsoft.CodeAnalysis.Text.SourceText.From(sourceText, Encoding.UTF8)
		);

		DependencyInjectionClassEmitter.GenerateImplementation(
			GenerationType.Logging,
			target.TelemetryGeneration,
			target.GenerationType,
			target.ClassNameToGenerate,
			target.InterfaceName,
			target.FullNamespace,
			context,
			logger
		);
	}

	static void EmitFields(
		LoggerTarget target,
		StringBuilder builder,
		int indent,
		SourceProductionContext context
	)
	{
		context.CancellationToken.ThrowIfCancellationRequested();

		builder
			.Append(indent + 1, "readonly ", withNewLine: false)
			.Append(Constants.Logging.MicrosoftExtensions.ILogger.WithGlobal())
			.Append('<')
			.Append(target.FullyQualifiedInterfaceName.WithGlobal())
			.Append('>')
			.Append(' ')
			.Append(Constants.Logging.LoggerFieldName)
			.Append(';')
			.AppendLine();
	}
}
