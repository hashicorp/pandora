using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2021_09_01.Registries;


internal class RegistryPropertiesUpdateParametersModel
{
    [JsonPropertyName("adminUserEnabled")]
    public bool? AdminUserEnabled { get; set; }

    [JsonPropertyName("dataEndpointEnabled")]
    public bool? DataEndpointEnabled { get; set; }

    [JsonPropertyName("encryption")]
    public EncryptionPropertyModel? Encryption { get; set; }

    [JsonPropertyName("networkRuleBypassOptions")]
    public NetworkRuleBypassOptionsConstant? NetworkRuleBypassOptions { get; set; }

    [JsonPropertyName("networkRuleSet")]
    public NetworkRuleSetModel? NetworkRuleSet { get; set; }

    [JsonPropertyName("policies")]
    public PoliciesModel? Policies { get; set; }

    [JsonPropertyName("publicNetworkAccess")]
    public PublicNetworkAccessConstant? PublicNetworkAccess { get; set; }
}
