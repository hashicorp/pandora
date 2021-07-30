using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.SignalR.v2020_05_01.SignalR
{

    internal class SignalRFeature
    {
        [JsonPropertyName("flag")]
        [Required]
        public FeatureFlags Flag { get; set; }

        [JsonPropertyName("properties")]
        public Dictionary<string, string>? Properties { get; set; }

        [JsonPropertyName("value")]
        [Required]
        public string Value { get; set; }
    }
}
