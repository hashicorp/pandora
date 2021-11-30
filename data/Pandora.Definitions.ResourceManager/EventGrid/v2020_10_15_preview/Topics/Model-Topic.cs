using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.Topics
{

    internal class TopicModel
    {
        [JsonPropertyName("extendedLocation")]
        public ExtendedLocationModel? ExtendedLocation { get; set; }

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("identity")]
        public CustomTypes.SystemUserAssignedIdentityMap? Identity { get; set; }

        [JsonPropertyName("kind")]
        public ResourceKindConstant? Kind { get; set; }

        [JsonPropertyName("location")]
        [Required]
        public CustomTypes.Location Location { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("properties")]
        public TopicPropertiesModel? Properties { get; set; }

        [JsonPropertyName("sku")]
        public ResourceSkuModel? Sku { get; set; }

        [JsonPropertyName("systemData")]
        public SystemDataModel? SystemData { get; set; }

        [JsonPropertyName("tags")]
        public CustomTypes.Tags? Tags { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }
    }
}
