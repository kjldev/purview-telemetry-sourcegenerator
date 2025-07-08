namespace Purview.Telemetry;

/// <summary>
/// Excludes the method from any activity, logging or meter generation.
/// </summary>
[global::System.AttributeUsage(global::System.AttributeTargets.Method, AllowMultiple = false)]
[global::System.Diagnostics.Conditional("PURVIEW_TELEMETRY_ATTRIBUTES")]
sealed class ExcludeAttribute : global::System.Attribute { }
