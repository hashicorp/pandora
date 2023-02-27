using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.KeyVault.v2022_11_01.Vaults;


internal class VaultPropertiesModel
{
    [JsonPropertyName("accessPolicies")]
    public List<AccessPolicyEntryModel>? AccessPolicies { get; set; }

    [JsonPropertyName("createMode")]
    public CreateModeConstant? CreateMode { get; set; }

    [JsonPropertyName("enablePurgeProtection")]
    public bool? EnablePurgeProtection { get; set; }

    [JsonPropertyName("enableRbacAuthorization")]
    public bool? EnableRbacAuthorization { get; set; }

    [JsonPropertyName("enableSoftDelete")]
    public bool? EnableSoftDelete { get; set; }

    [JsonPropertyName("enabledForDeployment")]
    public bool? EnabledForDeployment { get; set; }

    [JsonPropertyName("enabledForDiskEncryption")]
    public bool? EnabledForDiskEncryption { get; set; }

    [JsonPropertyName("enabledForTemplateDeployment")]
    public bool? EnabledForTemplateDeployment { get; set; }

    [JsonPropertyName("hsmPoolResourceId")]
    public string? HsmPoolResourceId { get; set; }

    [JsonPropertyName("networkAcls")]
    public NetworkRuleSetModel? NetworkAcls { get; set; }

    [JsonPropertyName("privateEndpointConnections")]
    public List<PrivateEndpointConnectionItemModel>? PrivateEndpointConnections { get; set; }

    [JsonPropertyName("provisioningState")]
    public VaultProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("publicNetworkAccess")]
    public string? PublicNetworkAccess { get; set; }

    [JsonPropertyName("sku")]
    [Required]
    public SkuModel Sku { get; set; }

    [JsonPropertyName("softDeleteRetentionInDays")]
    public int? SoftDeleteRetentionInDays { get; set; }

    [JsonPropertyName("tenantId")]
    [Required]
    public string TenantId { get; set; }

    [JsonPropertyName("vaultUri")]
    public string? VaultUri { get; set; }
}
