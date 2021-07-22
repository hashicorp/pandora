using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.EventHubs
{

    internal class AuthorizationRuleProperties
    {
        [JsonPropertyName("rights")]
        [Required]
        public List<string> Rights { get; set; }
    }
}
