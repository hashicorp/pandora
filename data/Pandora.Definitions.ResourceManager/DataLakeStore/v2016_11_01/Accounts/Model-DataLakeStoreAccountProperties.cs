using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataLakeStore.v2016_11_01.Accounts;


internal class DataLakeStoreAccountPropertiesModel
{
    [JsonPropertyName("accountId")]
    public string? AccountId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("creationTime")]
    public DateTime? CreationTime { get; set; }

    [JsonPropertyName("currentTier")]
    public TierTypeConstant? CurrentTier { get; set; }

    [JsonPropertyName("defaultGroup")]
    public string? DefaultGroup { get; set; }

    [JsonPropertyName("encryptionConfig")]
    public EncryptionConfigModel? EncryptionConfig { get; set; }

    [JsonPropertyName("encryptionProvisioningState")]
    public EncryptionProvisioningStateConstant? EncryptionProvisioningState { get; set; }

    [JsonPropertyName("encryptionState")]
    public EncryptionStateConstant? EncryptionState { get; set; }

    [JsonPropertyName("endpoint")]
    public string? Endpoint { get; set; }

    [JsonPropertyName("firewallAllowAzureIps")]
    public FirewallAllowAzureIpsStateConstant? FirewallAllowAzureIps { get; set; }

    [JsonPropertyName("firewallRules")]
    public List<FirewallRuleModel>? FirewallRules { get; set; }

    [JsonPropertyName("firewallState")]
    public FirewallStateConstant? FirewallState { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastModifiedTime")]
    public DateTime? LastModifiedTime { get; set; }

    [JsonPropertyName("newTier")]
    public TierTypeConstant? NewTier { get; set; }

    [JsonPropertyName("provisioningState")]
    public DataLakeStoreAccountStatusConstant? ProvisioningState { get; set; }

    [JsonPropertyName("state")]
    public DataLakeStoreAccountStateConstant? State { get; set; }

    [JsonPropertyName("trustedIdProviderState")]
    public TrustedIdProviderStateConstant? TrustedIdProviderState { get; set; }

    [JsonPropertyName("trustedIdProviders")]
    public List<TrustedIdProviderModel>? TrustedIdProviders { get; set; }

    [JsonPropertyName("virtualNetworkRules")]
    public List<VirtualNetworkRuleModel>? VirtualNetworkRules { get; set; }
}
