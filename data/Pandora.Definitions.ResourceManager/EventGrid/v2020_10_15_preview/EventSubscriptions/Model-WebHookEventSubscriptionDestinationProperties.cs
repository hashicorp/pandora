using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.EventSubscriptions
{

    internal class WebHookEventSubscriptionDestinationPropertiesModel
    {
        [JsonPropertyName("azureActiveDirectoryApplicationIdOrUri")]
        public string? AzureActiveDirectoryApplicationIdOrUri { get; set; }

        [JsonPropertyName("azureActiveDirectoryTenantId")]
        public string? AzureActiveDirectoryTenantId { get; set; }

        [JsonPropertyName("deliveryAttributeMappings")]
        public List<DeliveryAttributeMappingModel>? DeliveryAttributeMappings { get; set; }

        [JsonPropertyName("endpointBaseUrl")]
        public string? EndpointBaseUrl { get; set; }

        [JsonPropertyName("endpointUrl")]
        public string? EndpointUrl { get; set; }

        [JsonPropertyName("maxEventsPerBatch")]
        public int? MaxEventsPerBatch { get; set; }

        [JsonPropertyName("preferredBatchSizeInKilobytes")]
        public int? PreferredBatchSizeInKilobytes { get; set; }
    }
}
