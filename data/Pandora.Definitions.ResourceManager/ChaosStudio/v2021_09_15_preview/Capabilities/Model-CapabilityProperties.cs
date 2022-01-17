using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ChaosStudio.v2021_09_15_preview.Capabilities
{

    internal class CapabilityPropertiesModel
    {
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("parametersSchema")]
        public string? ParametersSchema { get; set; }

        [JsonPropertyName("publisher")]
        public string? Publisher { get; set; }

        [JsonPropertyName("targetType")]
        public string? TargetType { get; set; }

        [JsonPropertyName("urn")]
        public string? Urn { get; set; }
    }
}
