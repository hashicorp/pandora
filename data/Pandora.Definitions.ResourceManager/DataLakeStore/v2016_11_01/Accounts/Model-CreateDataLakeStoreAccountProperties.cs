using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.DataLakeStore.v2016_11_01.Accounts;


internal class CreateDataLakeStoreAccountPropertiesModel
{
    [JsonPropertyName("defaultGroup")]
    public string? DefaultGroup { get; set; }

    [JsonPropertyName("encryptionConfig")]
    public EncryptionConfigModel? EncryptionConfig { get; set; }

    [JsonPropertyName("encryptionState")]
    public EncryptionStateConstant? EncryptionState { get; set; }

    [JsonPropertyName("firewallAllowAzureIps")]
    public FirewallAllowAzureIpsStateConstant? FirewallAllowAzureIps { get; set; }

    [JsonPropertyName("firewallRules")]
    public List<CreateFirewallRuleWithAccountParametersModel>? FirewallRules { get; set; }

    [JsonPropertyName("firewallState")]
    public FirewallStateConstant? FirewallState { get; set; }

    [JsonPropertyName("newTier")]
    public TierTypeConstant? NewTier { get; set; }

    [JsonPropertyName("trustedIdProviderState")]
    public TrustedIdProviderStateConstant? TrustedIdProviderState { get; set; }

    [JsonPropertyName("trustedIdProviders")]
    public List<CreateTrustedIdProviderWithAccountParametersModel>? TrustedIdProviders { get; set; }

    [JsonPropertyName("virtualNetworkRules")]
    public List<CreateVirtualNetworkRuleWithAccountParametersModel>? VirtualNetworkRules { get; set; }
}
