using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.TrafficManager.v2018_08_01.Profiles
{

    internal class EndpointPropertiesSubnets
    {
        [JsonPropertyName("first")]
        public string? First { get; set; }

        [JsonPropertyName("last")]
        public string? Last { get; set; }

        [JsonPropertyName("scope")]
        public int? Scope { get; set; }
    }
}
