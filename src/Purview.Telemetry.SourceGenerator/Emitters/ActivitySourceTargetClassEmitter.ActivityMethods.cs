using System.Text;
using Microsoft.CodeAnalysis;
using Purview.Telemetry.SourceGenerator.Helpers;
using Purview.Telemetry.SourceGenerator.Records;

namespace Purview.Telemetry.SourceGenerator.Emitters;

partial class ActivitySourceTargetClassEmitter
{
	static void EmitActivityMethodBody(
		StringBuilder builder,
		int indent,
		ActivityBasedGenerationTarget methodTarget,
		SourceProductionContext context,
		GenerationLogger? logger
	)
	{
		context.CancellationToken.ThrowIfCancellationRequested();

		if (
			!GuardParameters(
				methodTarget,
				context,
				logger,
				out var activityParam,
				out var parentContextOrId,
				out var tagsParam,
				out var linksParam,
				out var startTimeParam,
				out var timestampParam,
				out var _,
				out var _
			)
		)
		{
			return;
		}

		if (activityParam != null)
		{
			logger?.Diagnostic(
				"Activity parameter not allowed on Activity start/ create method, only event."
			);

			TelemetryDiagnostics.Report(
				context.ReportDiagnostic,
				TelemetryDiagnostics.Activities.ActivityParameterNotAllowed,
				activityParam.Locations,
				activityParam.ParameterName
			);

			return;
		}

		if (timestampParam != null)
		{
			logger?.Diagnostic(
				"Timestamp parameter not allowed on Activity start/ create method, only events."
			);

			TelemetryDiagnostics.Report(
				context.ReportDiagnostic,
				TelemetryDiagnostics.Activities.TimestampParameterNotAllowed,
				timestampParam.Locations,
				timestampParam.ParameterName
			);

			return;
		}

		EmitHasListenersTest(builder, indent, methodTarget);

		var activityVariableName = "activity" + methodTarget.MethodName;

		builder
			.Append(
				indent,
				Constants.Activities.SystemDiagnostics.Activity.WithGlobal(),
				withNewLine: false
			)
			.Append("? ")
			.Append(activityVariableName)
			.Append(" = ")
			.Append(Constants.Activities.ActivitySourceFieldName)
			.Append('.');

		var createOnly = methodTarget.ActivityAttribute?.CreateOnly.Value == true;
		var createActivityMethod = createOnly ? "Create" : "Start";
		var parentContextParameterName =
			Constants.Activities.SystemDiagnostics.ActivityContext.Equals(
				parentContextOrId?.ParameterType
			)
				? "parentContext"
				: "parentId";

		if (createOnly && startTimeParam != null)
		{
			logger?.Diagnostic("StartTime parameter not allowed on Activity create method.");

			TelemetryDiagnostics.Report(
				context.ReportDiagnostic,
				TelemetryDiagnostics.Activities.StartTimeParameterNotAllowed,
				startTimeParam.Locations,
				startTimeParam.ParameterName
			);

			return;
		}

		var kind =
			methodTarget.ActivityAttribute?.Kind.IsSet == true
				? methodTarget.ActivityAttribute.Kind.Value!.Value
				: Constants.Activities.DefaultActivityKind;
		builder
			.Append(createActivityMethod)
			// name:
			.Append("Activity(name: ")
			.Append(methodTarget.ActivityOrEventName.Wrap())
			// kind:
			.Append(", kind: ")
			.Append(Constants.Activities.ActivityTypeMap[kind].WithGlobal())
			// parentContext/ parentId:
			.Append(", ")
			.Append(parentContextParameterName)
			.Append(": ")
			.Append(parentContextOrId?.ParameterName ?? "default")
			// tags:
			.Append(", tags: ")
			.Append(tagsParam?.ParameterName ?? "default")
			// links:
			.Append(", links: ")
			.Append(linksParam?.ParameterName ?? "default");

		if (!createOnly)
		{
			builder
				// startTime:
				.Append(", startTime: ")
				.Append(startTimeParam?.ParameterName ?? "default");
		}

		builder.AppendLine(");");

		context.CancellationToken.ThrowIfCancellationRequested();

		EmitTagsOrBaggageParameters(
			builder,
			indent,
			activityVariableName,
			true,
			methodTarget,
			true,
			context,
			logger
		);
		EmitTagsOrBaggageParameters(
			builder,
			indent,
			activityVariableName,
			false,
			methodTarget,
			true,
			context,
			logger
		);

		context.CancellationToken.ThrowIfCancellationRequested();

		if (Constants.Activities.SystemDiagnostics.Activity.Equals(methodTarget.ReturnType))
		{
			builder
				.AppendLine()
				.Append(indent, "return ", withNewLine: false)
				.Append(activityVariableName)
				.AppendLine(';');
		}
	}

	static void EmitHasListenersTest(
		StringBuilder builder,
		int indent,
		ActivityBasedGenerationTarget methodTarget
	)
	{
		var returnsVoid =
			methodTarget.ReturnType == null
			|| methodTarget.ReturnType == Constants.System.VoidKeyword;
		builder
			.Append(indent, "if (!", withNewLine: false)
			.Append(Constants.Activities.ActivitySourceFieldName)
			.Append(".HasListeners())")
			.AppendLine()
			.Append(indent, '{')
			.Append(
				indent + 1,
				"return"
					+ (returnsVoid ? null : " null" + (methodTarget.IsNullableReturn ? null : "!"))
					+ ";"
			)
			.Append(indent, '}')
			.AppendLine();
	}
}
