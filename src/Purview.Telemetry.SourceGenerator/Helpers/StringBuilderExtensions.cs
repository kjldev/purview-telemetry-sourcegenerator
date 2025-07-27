using System.Text;
using Purview.Telemetry.SourceGenerator.Templates;

namespace Purview.Telemetry.SourceGenerator.Helpers;

static class StringBuilderExtensions
{
	public static StringBuilder AggressiveInlining(this StringBuilder builder, int indent) =>
		builder.Append(indent, Constants.System.AggressiveInlining);

	public static StringBuilder CodeGen(this StringBuilder builder, int indent) =>
		builder.Append(indent, Constants.System.GeneratedCode.Value);

	public static StringBuilder IfDefines(
		this StringBuilder builder,
		string condition,
		params string[] values
	) => builder.IfDefines(condition, 0, values);

	public static StringBuilder IfDefines(
		this StringBuilder builder,
		string condition,
		int indent,
		params string[] values
	)
	{
		builder.AppendLine().Append("#if ").AppendLine(condition).WithIndent(indent);

		foreach (var value in values)
			builder.Append(value);

		builder.AppendLine().AppendLine("#endif");

		return builder;
	}

	public static StringBuilder WithIndent(this StringBuilder builder, int tabs)
	{
		for (var i = 0; i < tabs; i++)
			builder.Append('\t');

		return builder;
	}

	public static StringBuilder Append(
		this StringBuilder builder,
		int tabs,
		char value,
		bool withNewLine = true
	)
	{
		builder.WithIndent(tabs).Append(value);

		if (withNewLine)
			builder.AppendLine();

		return builder;
	}

	public static StringBuilder Append(
		this StringBuilder builder,
		int tabs,
		string value,
		bool withNewLine = true
	)
	{
		builder.WithIndent(tabs).Append(value);

		if (withNewLine)
			builder.AppendLine();

		return builder;
	}

	public static StringBuilder Append(
		this StringBuilder builder,
		int tabs,
		PurviewTypeInfo typeInfo,
		bool withNewLine = true
	)
	{
		builder.WithIndent(tabs).Append(typeInfo);

		if (withNewLine)
			builder.AppendLine();

		return builder;
	}

	public static StringBuilder AppendLine(this StringBuilder builder, char @char) =>
		builder.Append(@char).AppendLine();
}
