using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Relay.v2017_04_01.HybridConnections
{

    internal class RegenerateAccessKeyParameters
    {
        [JsonPropertyName("key")]
        public string? Key { get; set; }

        [JsonPropertyName("keyType")]
        [Required]
        public KeyType KeyType { get; set; }
    }
}
