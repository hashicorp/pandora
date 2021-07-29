using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.SignalR.v2020_05_01.SignalR
{

    internal class PrivateEndpointACL
    {
        [JsonPropertyName("allow")]
        public List<SignalRRequestType>? Allow { get; set; }

        [JsonPropertyName("deny")]
        public List<SignalRRequestType>? Deny { get; set; }

        [JsonPropertyName("name")]
        [Required]
        public string Name { get; set; }
    }
}
