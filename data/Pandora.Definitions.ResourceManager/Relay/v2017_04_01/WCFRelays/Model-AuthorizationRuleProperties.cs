using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Relay.v2017_04_01.WCFRelays
{

    internal class AuthorizationRulePropertiesModel
    {
        [JsonPropertyName("rights")]
        [Required]
        public List<AccessRightsConstant> Rights { get; set; }
    }
}
