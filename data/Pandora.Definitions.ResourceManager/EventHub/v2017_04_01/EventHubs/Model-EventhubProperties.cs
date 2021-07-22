using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.EventHubs
{

    internal class EventhubProperties
    {
        [JsonPropertyName("captureDescription")]
        public CaptureDescription? CaptureDescription { get; set; }

        [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("messageRetentionInDays")]
        public int MessageRetentionInDays { get; set; }

        [JsonPropertyName("partitionCount")]
        public int PartitionCount { get; set; }

        [JsonPropertyName("partitionIds")]
        public List<string>? PartitionIds { get; set; }

        [JsonPropertyName("status")]
        public EntityStatus Status { get; set; }

        [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }
}
