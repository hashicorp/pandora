using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.Topics
{

    internal class TopicPropertiesModel
    {
        [JsonPropertyName("endpoint")]
        public string? Endpoint { get; set; }

        [JsonPropertyName("inboundIpRules")]
        public List<InboundIpRuleModel>? InboundIpRules { get; set; }

        [JsonPropertyName("inputSchema")]
        public InputSchemaConstant? InputSchema { get; set; }

        [JsonPropertyName("inputSchemaMapping")]
        public InputSchemaMappingModel? InputSchemaMapping { get; set; }

        [JsonPropertyName("metricResourceId")]
        public string? MetricResourceId { get; set; }

        [JsonPropertyName("privateEndpointConnections")]
        public List<PrivateEndpointConnectionModel>? PrivateEndpointConnections { get; set; }

        [JsonPropertyName("provisioningState")]
        public TopicProvisioningStateConstant? ProvisioningState { get; set; }

        [JsonPropertyName("publicNetworkAccess")]
        public PublicNetworkAccessConstant? PublicNetworkAccess { get; set; }
    }
}
