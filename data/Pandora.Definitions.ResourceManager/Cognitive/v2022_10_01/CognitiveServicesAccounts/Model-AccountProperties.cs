using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Cognitive.v2022_10_01.CognitiveServicesAccounts;


internal class AccountPropertiesModel
{
    [JsonPropertyName("allowedFqdnList")]
    public List<string>? AllowedFqdnList { get; set; }

    [JsonPropertyName("apiProperties")]
    public ApiPropertiesModel? ApiProperties { get; set; }

    [JsonPropertyName("callRateLimit")]
    public CallRateLimitModel? CallRateLimit { get; set; }

    [JsonPropertyName("capabilities")]
    public List<SkuCapabilityModel>? Capabilities { get; set; }

    [JsonPropertyName("customSubDomainName")]
    public string? CustomSubDomainName { get; set; }

    [JsonPropertyName("dateCreated")]
    public string? DateCreated { get; set; }

    [JsonPropertyName("deletionDate")]
    public string? DeletionDate { get; set; }

    [JsonPropertyName("disableLocalAuth")]
    public bool? DisableLocalAuth { get; set; }

    [JsonPropertyName("dynamicThrottlingEnabled")]
    public bool? DynamicThrottlingEnabled { get; set; }

    [JsonPropertyName("encryption")]
    public EncryptionModel? Encryption { get; set; }

    [JsonPropertyName("endpoint")]
    public string? Endpoint { get; set; }

    [JsonPropertyName("endpoints")]
    public Dictionary<string, string>? Endpoints { get; set; }

    [JsonPropertyName("internalId")]
    public string? InternalId { get; set; }

    [JsonPropertyName("isMigrated")]
    public bool? IsMigrated { get; set; }

    [JsonPropertyName("migrationToken")]
    public string? MigrationToken { get; set; }

    [JsonPropertyName("networkAcls")]
    public NetworkRuleSetModel? NetworkAcls { get; set; }

    [JsonPropertyName("privateEndpointConnections")]
    public List<PrivateEndpointConnectionModel>? PrivateEndpointConnections { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("publicNetworkAccess")]
    public PublicNetworkAccessConstant? PublicNetworkAccess { get; set; }

    [JsonPropertyName("quotaLimit")]
    public QuotaLimitModel? QuotaLimit { get; set; }

    [JsonPropertyName("restore")]
    public bool? Restore { get; set; }

    [JsonPropertyName("restrictOutboundNetworkAccess")]
    public bool? RestrictOutboundNetworkAccess { get; set; }

    [JsonPropertyName("scheduledPurgeDate")]
    public string? ScheduledPurgeDate { get; set; }

    [JsonPropertyName("skuChangeInfo")]
    public SkuChangeInfoModel? SkuChangeInfo { get; set; }

    [JsonPropertyName("userOwnedStorage")]
    public List<UserOwnedStorageModel>? UserOwnedStorage { get; set; }
}
