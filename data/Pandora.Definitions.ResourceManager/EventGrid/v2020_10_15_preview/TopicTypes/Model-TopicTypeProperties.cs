using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.TopicTypes
{

    internal class TopicTypePropertiesModel
    {
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("displayName")]
        public string? DisplayName { get; set; }

        [JsonPropertyName("provider")]
        public string? Provider { get; set; }

        [JsonPropertyName("provisioningState")]
        public TopicTypeProvisioningStateConstant? ProvisioningState { get; set; }

        [JsonPropertyName("resourceRegionType")]
        public ResourceRegionTypeConstant? ResourceRegionType { get; set; }

        [JsonPropertyName("sourceResourceFormat")]
        public string? SourceResourceFormat { get; set; }

        [JsonPropertyName("supportedLocations")]
        public List<string>? SupportedLocations { get; set; }

        [JsonPropertyName("supportedScopesForSource")]
        public List<SupportedScopesForSourceConstant>? SupportedScopesForSource { get; set; }
    }
}
