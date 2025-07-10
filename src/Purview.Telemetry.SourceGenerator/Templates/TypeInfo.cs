using Microsoft.CodeAnalysis;
using Purview.Telemetry.SourceGenerator.Helpers;

namespace Purview.Telemetry.SourceGenerator.Templates;

record TypeInfo(string Name, string FullName, string Namespace) : IEquatable<string>
{
	public bool Equals(string? other)
	{
		if (other == null)
			return false;

		if (other.Length > 0 && other[other.Length - 1] == '?')
			other = other.Substring(0, other.Length - 1);

		return other == Name || other == FullName;
	}

	public bool Equals(ITypeSymbol other)
	{
		if (other == null)
			return false;

		var typeName = other.ToString();
		if (other.NullableAnnotation == NullableAnnotation.Annotated)
			typeName = typeName.TrimEnd('?');

		var idx = typeName.IndexOf('<');
		if (idx > -1)
			typeName = typeName.Substring(0, idx);

		return Equals(typeName) || Equals(other.Name);
	}

	public string MakeGeneric(params string[] types) =>
		FullName + "<" + string.Join(", ", types) + ">";

	public string WithGlobal() => FullName.WithGlobal();

	public override string ToString() => FullName;

	public static implicit operator string(TypeInfo typeInfo) => typeInfo.FullName;

	public static TypeInfo Create(string fullName)
	{
		if (string.IsNullOrWhiteSpace(fullName))
			throw new ArgumentNullException(nameof(fullName));

		var @parts = fullName.Split('.');

		return new(
			parts.LastOrDefault() ?? fullName,
			fullName,
			string.Join(".", parts.Take(parts.Length - 2))
		);
	}

	public static TypeInfo Create<T>() => Create(typeof(T).FullName);
}
