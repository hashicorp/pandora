using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.Namespaces
{

    internal class EHNamespaceProperties
    {
        [JsonPropertyName("clusterArmId")]
        public string? ClusterArmId { get; set; }

        [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("encryption")]
        public Encryption? Encryption { get; set; }

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

        [JsonPropertyName("zoneRedundant")]
        public bool ZoneRedundant { get; set; }
    }
}
