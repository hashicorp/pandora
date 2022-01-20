using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.DataLakeAnalytics.v2016_11_01.FirewallRules;


internal class FirewallRulePropertiesModel
{
    [JsonPropertyName("endIpAddress")]
    public string? EndIpAddress { get; set; }

    [JsonPropertyName("startIpAddress")]
    public string? StartIpAddress { get; set; }
}
