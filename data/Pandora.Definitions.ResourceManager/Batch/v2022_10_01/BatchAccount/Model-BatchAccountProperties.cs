using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Batch.v2022_10_01.BatchAccount;


internal class BatchAccountPropertiesModel
{
    [JsonPropertyName("accountEndpoint")]
    public string? AccountEndpoint { get; set; }

    [JsonPropertyName("activeJobAndJobScheduleQuota")]
    public int? ActiveJobAndJobScheduleQuota { get; set; }

    [JsonPropertyName("allowedAuthenticationModes")]
    public List<AuthenticationModeConstant>? AllowedAuthenticationModes { get; set; }

    [JsonPropertyName("autoStorage")]
    public AutoStoragePropertiesModel? AutoStorage { get; set; }

    [JsonPropertyName("dedicatedCoreQuota")]
    public int? DedicatedCoreQuota { get; set; }

    [JsonPropertyName("dedicatedCoreQuotaPerVMFamily")]
    public List<VirtualMachineFamilyCoreQuotaModel>? DedicatedCoreQuotaPerVMFamily { get; set; }

    [JsonPropertyName("dedicatedCoreQuotaPerVMFamilyEnforced")]
    public bool? DedicatedCoreQuotaPerVMFamilyEnforced { get; set; }

    [JsonPropertyName("encryption")]
    public EncryptionPropertiesModel? Encryption { get; set; }

    [JsonPropertyName("keyVaultReference")]
    public KeyVaultReferenceModel? KeyVaultReference { get; set; }

    [JsonPropertyName("lowPriorityCoreQuota")]
    public int? LowPriorityCoreQuota { get; set; }

    [JsonPropertyName("networkProfile")]
    public NetworkProfileModel? NetworkProfile { get; set; }

    [JsonPropertyName("nodeManagementEndpoint")]
    public string? NodeManagementEndpoint { get; set; }

    [JsonPropertyName("poolAllocationMode")]
    public PoolAllocationModeConstant? PoolAllocationMode { get; set; }

    [JsonPropertyName("poolQuota")]
    public int? PoolQuota { get; set; }

    [JsonPropertyName("privateEndpointConnections")]
    public List<PrivateEndpointConnectionModel>? PrivateEndpointConnections { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("publicNetworkAccess")]
    public PublicNetworkAccessTypeConstant? PublicNetworkAccess { get; set; }
}
