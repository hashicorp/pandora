using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.SystemTopics
{

    internal class SystemTopicPropertiesModel
    {
        [JsonPropertyName("metricResourceId")]
        public string? MetricResourceId { get; set; }

        [JsonPropertyName("provisioningState")]
        public ResourceProvisioningStateConstant? ProvisioningState { get; set; }

        [JsonPropertyName("source")]
        public string? Source { get; set; }

        [JsonPropertyName("topicType")]
        public string? TopicType { get; set; }
    }
}
