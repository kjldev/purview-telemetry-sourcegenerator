﻿//HintName: Testing.TestMetricsCore.Metric.g.cs
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the Purview.Telemetry.SourceGenerator
//     on {Scrubbed}.
//
//     Changes to this file may cause incorrect behaviour and will be lost
//     when the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#pragma warning disable 1591 // publicly visible type or member must be documented

#nullable enable

namespace Testing
{
	[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Purview.Telemetry.SourceGenerator", "0.1.0.0")]
	sealed partial class TestMetricsCore : global::Testing.ITestMetrics
	{
		global::System.Diagnostics.Metrics.Meter _meter = default!;

		global::System.Diagnostics.Metrics.ObservableCounter<byte>? _metricInstrument = null;

		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Purview.Telemetry.SourceGenerator", "0.1.0.0")]
		public TestMetricsCore(global::System.Diagnostics.Metrics.IMeterFactory meterFactory)
		{
			InitializeMeters(meterFactory);
		}

		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Purview.Telemetry.SourceGenerator", "0.1.0.0")]
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		void InitializeMeters(global::System.Diagnostics.Metrics.IMeterFactory meterFactory)
		{
			if (_meter != null)
			{
				throw new global::System.Exception("The meters have already been initialized.");
			}

			global::System.Collections.Generic.Dictionary<string, object?> meterTags = new();

			PopulateMeterTags(meterTags);

			_meter = meterFactory.Create(new global::System.Diagnostics.Metrics.MeterOptions("testing-meter")
			{
				Version = null,
				Tags = meterTags
			});

		}

		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Purview.Telemetry.SourceGenerator", "0.1.0.0")]
		partial void PopulateMeterTags(global::System.Collections.Generic.Dictionary<string, object?> meterTags);

		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Purview.Telemetry.SourceGenerator", "0.1.0.0")]
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void Metric(System.Func<byte> f, int intParam, bool boolParam)
		{
			if (_metricInstrument != null)
			{
				return;
			}

			global::System.Diagnostics.TagList metricTagList = new();

			metricTagList.Add("intparam", intParam);
			metricTagList.Add("boolparam", boolParam);

			_metricInstrument = _meter.CreateObservableCounter<byte>("an-observablecounter-name-property", f, unit: "pie-property", description: "pie sales per-capita-property."
				, tags: metricTagList
			);
		}
	}
}
