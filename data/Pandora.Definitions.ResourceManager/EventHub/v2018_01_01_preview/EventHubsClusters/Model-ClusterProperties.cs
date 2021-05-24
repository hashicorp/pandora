using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.EventHubsClusters
{

	internal class ClusterProperties
	{
		[JsonPropertyName("createdAt")]
		public string? CreatedAt { get; set; }

		[JsonPropertyName("metricId")]
		public string? MetricId { get; set; }

		[JsonPropertyName("status")]
		public string? Status { get; set; }

		[JsonPropertyName("updatedAt")]
		public string? UpdatedAt { get; set; }
	}
}
