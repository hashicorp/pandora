using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.Namespaces
{

	internal class EHNamespaceProperties
	{
		[DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
		[JsonPropertyName("createdAt")]
		public DateTime CreatedAt { get; set; }

		[JsonPropertyName("isAutoInflateEnabled")]
		public bool IsAutoInflateEnabled { get; set; }

		[JsonPropertyName("kafkaEnabled")]
		public bool KafkaEnabled { get; set; }

		[JsonPropertyName("maximumThroughputUnits")]
		public int MaximumThroughputUnits { get; set; }

		[JsonPropertyName("metricId")]
		public string? MetricId { get; set; }

		[JsonPropertyName("provisioningState")]
		public string? ProvisioningState { get; set; }

		[JsonPropertyName("serviceBusEndpoint")]
		public string? ServiceBusEndpoint { get; set; }

		[DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
		[JsonPropertyName("updatedAt")]
		public DateTime UpdatedAt { get; set; }
	}
}
