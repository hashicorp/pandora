using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.AuthorizationRulesNamespaces
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
