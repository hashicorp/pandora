using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_11_01.AuthorizationRulesDisasterRecoveryConfigs;


internal class AuthorizationRulePropertiesModel
{
    [JsonPropertyName("rights")]
    [Required]
    public List<AccessRightsConstant> Rights { get; set; }
}
