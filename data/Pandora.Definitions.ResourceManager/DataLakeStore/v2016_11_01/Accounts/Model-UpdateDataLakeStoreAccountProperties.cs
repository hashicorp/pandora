using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataLakeStore.v2016_11_01.Accounts;


internal class UpdateDataLakeStoreAccountPropertiesModel
{
    [JsonPropertyName("defaultGroup")]
    public string? DefaultGroup { get; set; }

    [JsonPropertyName("encryptionConfig")]
    public UpdateEncryptionConfigModel? EncryptionConfig { get; set; }

    [JsonPropertyName("firewallAllowAzureIps")]
    public FirewallAllowAzureIPsStateConstant? FirewallAllowAzureIPs { get; set; }

    [JsonPropertyName("firewallRules")]
    public List<UpdateFirewallRuleWithAccountParametersModel>? FirewallRules { get; set; }

    [JsonPropertyName("firewallState")]
    public FirewallStateConstant? FirewallState { get; set; }

    [JsonPropertyName("newTier")]
    public TierTypeConstant? NewTier { get; set; }

    [JsonPropertyName("trustedIdProviderState")]
    public TrustedIdProviderStateConstant? TrustedIdProviderState { get; set; }

    [JsonPropertyName("trustedIdProviders")]
    public List<UpdateTrustedIdProviderWithAccountParametersModel>? TrustedIdProviders { get; set; }

    [JsonPropertyName("virtualNetworkRules")]
    public List<UpdateVirtualNetworkRuleWithAccountParametersModel>? VirtualNetworkRules { get; set; }
}
