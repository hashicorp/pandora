using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.StorageAccounts;


internal class NetworkRuleSetModel
{
    [JsonPropertyName("bypass")]
    public BypassConstant? Bypass { get; set; }

    [JsonPropertyName("defaultAction")]
    [Required]
    public DefaultActionConstant DefaultAction { get; set; }

    [JsonPropertyName("ipRules")]
    public List<IPRuleModel>? IpRules { get; set; }

    [JsonPropertyName("resourceAccessRules")]
    public List<ResourceAccessRuleModel>? ResourceAccessRules { get; set; }

    [JsonPropertyName("virtualNetworkRules")]
    public List<VirtualNetworkRuleModel>? VirtualNetworkRules { get; set; }
}
