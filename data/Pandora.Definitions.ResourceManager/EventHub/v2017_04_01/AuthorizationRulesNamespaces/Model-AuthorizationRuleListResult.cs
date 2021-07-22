using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.AuthorizationRulesNamespaces
{

    internal class AuthorizationRuleListResult
    {
        [JsonPropertyName("nextLink")]
        public string? NextLink { get; set; }

        [JsonPropertyName("value")]
        public List<AuthorizationRule>? Value { get; set; }
    }
}
