using System.Collections.Immutable;
using Purview.Telemetry.SourceGenerator.Templates;

namespace Purview.Telemetry;

partial class Constants
{
	public static partial class Activities
	{
		public const bool UseRecordExceptionRulesDefault = true;
		public const bool RecordExceptionEscapedDefault = true;

		public const string DefaultActivitySourceName = "purview";
		public const int DefaultActivityKind = 0;

		public const string ActivitySourceFieldName = "_activitySource";
		public const string ActivityVariableName = "activity";

		public const string ParentIdParameterName = "parentId";
		public const string StartTimeParameterName = "startTime";

		public const string TimeStampParameterName = "timestamp";

		public const string StatusCode_Key = "otel.status_code";
		public const string StatusDescription_Key = "otel.status_description";

		public const string Tag_ExceptionEventName = "exception";
		public const string Tag_ExceptionEscaped = "exception.escaped";
		public const string Tag_ExceptionType = "exception.type";
		public const string Tag_ExceptionMessage = "exception.message";
		public const string Tag_ExceptionStackTrace = "exception.stacktrace";

		public const string RecordExceptionMethodName = "RecordExceptionInternal";

		public static readonly TemplateInfo ActivitySourceGenerationAttribute = TemplateInfo.Create(
			"Purview.Telemetry.Activities.ActivitySourceGenerationAttribute"
		);
		public static readonly TemplateInfo ActivitySourceAttribute = TemplateInfo.Create(
			"Purview.Telemetry.Activities.ActivitySourceAttribute"
		);
		public static readonly TemplateInfo ActivityAttribute = TemplateInfo.Create(
			"Purview.Telemetry.Activities.ActivityAttribute"
		);
		public static readonly TemplateInfo EventAttribute = TemplateInfo.Create(
			"Purview.Telemetry.Activities.EventAttribute"
		);
		public static readonly TemplateInfo ContextAttribute = TemplateInfo.Create(
			"Purview.Telemetry.Activities.ContextAttribute"
		);
		public static readonly TemplateInfo BaggageAttribute = TemplateInfo.Create(
			"Purview.Telemetry.Activities.BaggageAttribute"
		);
		public static readonly TemplateInfo EscapeAttribute = TemplateInfo.Create(
			"Purview.Telemetry.Activities.EscapeAttribute"
		);
		public static readonly TemplateInfo StatusDescriptionAttribute = TemplateInfo.Create(
			"Purview.Telemetry.Activities.StatusDescriptionAttribute"
		);

		public static readonly ImmutableDictionary<int, TypeInfo> ActivityTypeMap = new Dictionary<
			int,
			TypeInfo
		>
		{
			{ 0, SystemDiagnostics.ActivityKind_Internal },
			{ 1, SystemDiagnostics.ActivityKind_Server },
			{ 2, SystemDiagnostics.ActivityKind_Client },
			{ 3, SystemDiagnostics.ActivityKind_Producer },
			{ 4, SystemDiagnostics.ActivityKind_Consumer },
		}.ToImmutableDictionary();

		public static readonly ImmutableDictionary<int, TypeInfo> ActivityStatusCodeMap =
			new Dictionary<int, TypeInfo>
			{
				{ 0, SystemDiagnostics.ActivityStatusCode_Unset },
				{ 1, SystemDiagnostics.ActivityStatusCode_Ok },
				{ 2, SystemDiagnostics.ActivityStatusCode_Error },
			}.ToImmutableDictionary();

		public static TemplateInfo[] GetTemplates() =>
			[
				ActivitySourceGenerationAttribute,
				ActivitySourceAttribute,
				ActivityAttribute,
				EventAttribute,
				ContextAttribute,
				BaggageAttribute,
				EscapeAttribute,
				StatusDescriptionAttribute,
			];

		public static class SystemDiagnostics
		{
			public static readonly TypeInfo Activity = TypeInfo.Create(
				SystemDiagnosticsNamespace + ".Activity"
			);
			public static readonly TypeInfo ActivitySource = TypeInfo.Create(
				SystemDiagnosticsNamespace + ".ActivitySource"
			);
			public static readonly TypeInfo ActivityEvent = TypeInfo.Create(
				SystemDiagnosticsNamespace + ".ActivityEvent"
			);
			public static readonly TypeInfo ActivityContext = TypeInfo.Create(
				SystemDiagnosticsNamespace + ".ActivityContext"
			);
			public static readonly TypeInfo ActivityKind = TypeInfo.Create(
				SystemDiagnosticsNamespace + ".ActivityKind"
			);
			public static readonly TypeInfo ActivityStatusCode = TypeInfo.Create(
				SystemDiagnosticsNamespace + ".ActivityStatusCode"
			);
			public static readonly TypeInfo ActivityTagsCollection = TypeInfo.Create(
				SystemDiagnosticsNamespace + ".ActivityTagsCollection"
			);
			public static readonly TypeInfo ActivityTagIEnumerable = TypeInfo.Create(
				"System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, object?>>"
			);

			public static readonly TypeInfo ActivityLink = TypeInfo.Create(
				SystemDiagnosticsNamespace + ".ActivityLink"
			);
			public static readonly TypeInfo ActivityLinkIEnumerable = TypeInfo.Create(
				"System.Collections.Generic.IEnumerable<System.Diagnostics.ActivityLink>"
			);
			public static readonly TypeInfo ActivityLinkArray = TypeInfo.Create(
				SystemDiagnosticsNamespace + ".ActivityLink[]"
			);

			public static readonly TypeInfo ActivityKind_Internal = TypeInfo.Create(
				ActivityKind + ".Internal"
			);
			public static readonly TypeInfo ActivityKind_Server = TypeInfo.Create(
				ActivityKind + ".Server"
			);
			public static readonly TypeInfo ActivityKind_Client = TypeInfo.Create(
				ActivityKind + ".Client"
			);
			public static readonly TypeInfo ActivityKind_Producer = TypeInfo.Create(
				ActivityKind + ".Producer"
			);
			public static readonly TypeInfo ActivityKind_Consumer = TypeInfo.Create(
				ActivityKind + ".Consumer"
			);

			public static readonly TypeInfo ActivityStatusCode_Unset = TypeInfo.Create(
				ActivityStatusCode + ".Unset"
			);
			public static readonly TypeInfo ActivityStatusCode_Ok = TypeInfo.Create(
				ActivityStatusCode + ".Ok"
			);
			public static readonly TypeInfo ActivityStatusCode_Error = TypeInfo.Create(
				ActivityStatusCode + ".Error"
			);
		}
	}
}
