using System.Globalization;
using Purview.Telemetry.SourceGenerator.Templates;

namespace Purview.Telemetry;

partial class Constants
{
	public static Lazy<Version> Version = new(() => typeof(Constants).Assembly.GetName().Version!);

	public static class System
	{
		public const string VoidKeyword = "void";
		public const string ObjectKeyword = "object";

		public const string StringKeyword = "string";
		public const string BoolKeyword = "bool";
		public const string ByteKeyword = "byte";
		public const string ShortKeyword = "short";
		public const string IntKeyword = "int";
		public const string LongKeyword = "long";
		public const string FloatKeyword = "float";
		public const string DoubleKeyword = "double";
		public const string DecimalKeyword = "decimal";

		public const string NullKeyword = "null";
		public const string DefaultKeyword = "default";

		public static readonly TypeInfo Func = TypeInfo.Create("System.Func"); // <T>
		public static readonly TypeInfo Action = TypeInfo.Create("System.Action"); // <T>

		public static readonly TypeInfo String = TypeInfo.Create<string>();
		public static readonly TypeInfo Boolean = TypeInfo.Create<bool>();
		public static readonly TypeInfo Byte = TypeInfo.Create<byte>();
		public static readonly TypeInfo Int16 = TypeInfo.Create<short>(); // int16
		public static readonly TypeInfo Int32 = TypeInfo.Create<int>(); // int32
		public static readonly TypeInfo Int64 = TypeInfo.Create<long>(); // int64
		public static readonly TypeInfo Single = TypeInfo.Create<float>(); // single
		public static readonly TypeInfo Double = TypeInfo.Create<double>();
		public static readonly TypeInfo Decimal = TypeInfo.Create<decimal>();
		public static readonly TypeInfo DateTimeOffset = TypeInfo.Create<DateTimeOffset>();

		public static readonly TypeInfo IEnumerable = TypeInfo.Create(
			"System.Collections.IEnumerable"
		);
		public static readonly TypeInfo GenericIEnumerable = TypeInfo.Create(
			"System.Collections.Generic.IEnumerable"
		); // <>
		public static readonly TypeInfo List = TypeInfo.Create("System.Collections.Generic.List"); // <>
		public static readonly TypeInfo Dictionary = TypeInfo.Create(
			"System.Collections.Generic.Dictionary"
		); // <>
		public static readonly TypeInfo ConcurrentDictionary = TypeInfo.Create(
			"System.Collections.Concurrent.ConcurrentDictionary"
		); // <>

		public static readonly TypeInfo IDisposable = TypeInfo.Create<IDisposable>();
		public static readonly TypeInfo Exception = TypeInfo.Create<Exception>();

		public static readonly TypeInfo TagList = TypeInfo.Create(
			SystemDiagnosticsNamespace + ".TagList"
		);

		public const string AggressiveInlining =
			"[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]";

		const string GeneratedCodeConstant =
			"[global::System.CodeDom.Compiler.GeneratedCodeAttribute(\"{0}\", \"{1}\")]";

		public static readonly Lazy<string> GeneratedCode = new(() =>
			string.Format(
				CultureInfo.InvariantCulture,
				GeneratedCodeConstant,
				"Purview.Telemetry.SourceGenerator",
				Version.Value
			)
		);
	}
}
