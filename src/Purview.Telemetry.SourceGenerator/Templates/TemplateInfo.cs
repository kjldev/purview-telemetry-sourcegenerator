using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Purview.Telemetry.SourceGenerator.Templates;

record TemplateInfo(
	string Name,
	string FullName,
	string Namespace,
	string? Source,
	string TemplateData
)
	: IEquatable<NameSyntax>,
		IEquatable<AttributeSyntax>,
		IEquatable<ISymbol>,
		IEquatable<string>,
		IEquatable<AttributeData>
{
	public string GetGeneratedFilename() => $"{Name}.g.cs";

	public bool Equals(string other) => other == FullName || other == Name;

	public bool Equals(NameSyntax other)
	{
		var isAttribute = Name.EndsWith("Attribute", StringComparison.Ordinal);

		var name = other.ToString();

		var result = Equals(name);
		if (!result && isAttribute)
			result = Equals(name + "Attribute");

		return result;
	}

	public bool Equals(AttributeSyntax other) => Equals(other.Name);

	public bool Equals(ISymbol other) => Equals(other.ToString());

	public bool Equals(AttributeData other) =>
		(other.AttributeClass != null) && Equals(other.AttributeClass);

	public string MakeGeneric(params string[] types) =>
		FullName + "<" + string.Join(", ", types) + ">";

	public static TemplateInfo Create<T>(bool attachHeader = true) =>
		Create(typeof(T).FullName, attachHeader);

	public static TemplateInfo Create(string fullTypeName, bool attachHeader = true)
	{
		var parts = fullTypeName.Split('.');

		var typeName = RemoveGenericTypeInfo(parts.Last());
		fullTypeName = RemoveGenericTypeInfo(fullTypeName);

		var @namespace = fullTypeName.Substring(0, fullTypeName.Length - (typeName.Length + 1));
		var source = @namespace.Split('.');
		var isRootSources = source.Length == 2;
		var sourceToUse = isRootSources ? null : source.Last();

		var template = EmbeddedResources.Instance.LoadTemplateForEmitting(
			sourceToUse,
			typeName,
			attachHeader
		);
		TemplateInfo templateInfo = new(typeName, fullTypeName, @namespace, sourceToUse, template);

		return templateInfo;
	}

	static string RemoveGenericTypeInfo(string identifier)
	{
		var idx = identifier.IndexOf('`');
		if (idx > -1)
			identifier = identifier.Substring(0, idx);

		return identifier;
	}

	public static implicit operator string(TemplateInfo templateInfo) => templateInfo.FullName;
}
