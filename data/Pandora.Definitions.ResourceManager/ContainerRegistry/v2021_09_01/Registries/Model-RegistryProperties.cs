using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2021_09_01.Registries;


internal class RegistryPropertiesModel
{
    [JsonPropertyName("adminUserEnabled")]
    public bool? AdminUserEnabled { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("creationDate")]
    public DateTime? CreationDate { get; set; }

    [JsonPropertyName("dataEndpointEnabled")]
    public bool? DataEndpointEnabled { get; set; }

    [JsonPropertyName("dataEndpointHostNames")]
    public List<string>? DataEndpointHostNames { get; set; }

    [JsonPropertyName("encryption")]
    public EncryptionPropertyModel? Encryption { get; set; }

    [JsonPropertyName("loginServer")]
    public string? LoginServer { get; set; }

    [JsonPropertyName("networkRuleBypassOptions")]
    public NetworkRuleBypassOptionsConstant? NetworkRuleBypassOptions { get; set; }

    [JsonPropertyName("networkRuleSet")]
    public NetworkRuleSetModel? NetworkRuleSet { get; set; }

    [JsonPropertyName("policies")]
    public PoliciesModel? Policies { get; set; }

    [JsonPropertyName("privateEndpointConnections")]
    public List<PrivateEndpointConnectionModel>? PrivateEndpointConnections { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("publicNetworkAccess")]
    public PublicNetworkAccessConstant? PublicNetworkAccess { get; set; }

    [JsonPropertyName("status")]
    public StatusModel? Status { get; set; }

    [JsonPropertyName("zoneRedundancy")]
    public ZoneRedundancyConstant? ZoneRedundancy { get; set; }
}
