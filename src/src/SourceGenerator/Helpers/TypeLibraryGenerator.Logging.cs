namespace Purview.Telemetry.SourceGenerator.Helpers;

partial class TypeLibraryGenerator
{
	[TypeRef(LoggingNamespace)]
	static readonly TypeIdentity ILogger = default;

	[TypeRef(LoggingNamespace)]
	static readonly TypeIdentity LoggerMessage = default;

	[TypeRef(LoggingNamespace)]
	static readonly TypeIdentity LogLevel = default;

	[TypeRef(LoggingNamespace)]
	static readonly TypeIdentity EventId = default;

	[TypeRef(LoggingNamespace)]
	static readonly TypeIdentity LoggerMessageHelper = default;

	[TypeRef(LoggingNamespace)]
	static readonly TypeIdentity LogPropertiesAttribute = default;

	[TypeRef(LoggingNamespace)]
	static readonly TypeIdentity LogPropertyIgnoreAttribute = default;
}
