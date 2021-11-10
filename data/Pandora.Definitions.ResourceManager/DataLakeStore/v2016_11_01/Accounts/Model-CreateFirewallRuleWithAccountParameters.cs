using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.DataLakeStore.v2016_11_01.Accounts
{

    internal class CreateFirewallRuleWithAccountParametersModel
    {
        [JsonPropertyName("name")]
        [Required]
        public string Name { get; set; }

        [JsonPropertyName("properties")]
        [Required]
        public CreateOrUpdateFirewallRulePropertiesModel Properties { get; set; }
    }
}
