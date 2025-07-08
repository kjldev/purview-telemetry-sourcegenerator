using System.Diagnostics.CodeAnalysis;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace Microsoft.Extensions.Configuration;

#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ConfigurationExtensions
{
	public static string GetRequiredValue(
		[NotNull] this IConfiguration configuration,
		string name
	) =>
		configuration[name]
		?? throw new InvalidOperationException(
			$"Configuration missing value for: {(configuration is IConfigurationSection s ? s.Path + ":" + name : name)}"
		);
}
