namespace Purview.Telemetry.SourceGenerator.Templates;

record TemplateInfo(PurviewTypeInfo TypeInfo, string? Source, string TemplateData)
	: IEquatable<PurviewTypeInfo>
//IEquatable<NameSyntax>,
//IEquatable<AttributeSyntax>,
//IEquatable<ISymbol>,
//IEquatable<string>,
//IEquatable<AttributeData>
{
	public string Name => TypeInfo.TypeName;

	public string GetGeneratedFilename() => $"{Name}.g.cs";

	public bool Equals(PurviewTypeInfo? other) => other != null && other == TypeInfo;

	//public bool Equals(string other) =>
	//	other == TypeInfo.FullyQualifiedName || other == TypeInfo.TypeName;

	//public bool Equals(NameSyntax other)
	//{
	//	var isAttribute = Name.EndsWith("Attribute", StringComparison.Ordinal);

	//	var name = other.ToString();

	//	var result = Equals(name);
	//	if (!result && isAttribute)
	//		result = Equals(name + "Attribute");

	//	return result;
	//}

	//public bool Equals(AttributeSyntax other) => Equals(other.Name);

	//public bool Equals(ISymbol other) => Equals(other.ToString());

	//public bool Equals(AttributeData other) =>
	//	other != null
	//	&& other.AttributeClass != null
	//	&& Equals(PurviewTypeFactory.Create(other.AttributeClass));

	public static TemplateInfo Create(string fullTypeName, bool attachHeader = true)
	{
		var purviewType = PurviewTypeFactory.Create(fullTypeName);
		var source = purviewType.Namespace!.Split('.');
		var isRootSources = source.Length == 2;
		var sourceToUse = isRootSources ? null : source.Last();

		var template = EmbeddedResources.Instance.LoadTemplateForEmitting(
			sourceToUse,
			purviewType.TypeName,
			attachHeader
		);
		TemplateInfo templateInfo = new(purviewType, sourceToUse, template);

		return templateInfo;
	}

	public static implicit operator string(TemplateInfo templateInfo) => templateInfo.TypeInfo;
}
