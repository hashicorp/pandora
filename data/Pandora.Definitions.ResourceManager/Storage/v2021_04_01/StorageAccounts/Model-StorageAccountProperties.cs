using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.StorageAccounts;


internal class StorageAccountPropertiesModel
{
    [JsonPropertyName("accessTier")]
    public AccessTierConstant? AccessTier { get; set; }

    [JsonPropertyName("allowBlobPublicAccess")]
    public bool? AllowBlobPublicAccess { get; set; }

    [JsonPropertyName("allowCrossTenantReplication")]
    public bool? AllowCrossTenantReplication { get; set; }

    [JsonPropertyName("allowSharedKeyAccess")]
    public bool? AllowSharedKeyAccess { get; set; }

    [JsonPropertyName("azureFilesIdentityBasedAuthentication")]
    public AzureFilesIdentityBasedAuthenticationModel? AzureFilesIdentityBasedAuthentication { get; set; }

    [JsonPropertyName("blobRestoreStatus")]
    public BlobRestoreStatusModel? BlobRestoreStatus { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("creationTime")]
    public DateTime? CreationTime { get; set; }

    [JsonPropertyName("customDomain")]
    public CustomDomainModel? CustomDomain { get; set; }

    [JsonPropertyName("encryption")]
    public EncryptionModel? Encryption { get; set; }

    [JsonPropertyName("failoverInProgress")]
    public bool? FailoverInProgress { get; set; }

    [JsonPropertyName("geoReplicationStats")]
    public GeoReplicationStatsModel? GeoReplicationStats { get; set; }

    [JsonPropertyName("isHnsEnabled")]
    public bool? IsHnsEnabled { get; set; }

    [JsonPropertyName("isNfsV3Enabled")]
    public bool? IsNfsVThreeEnabled { get; set; }

    [JsonPropertyName("keyCreationTime")]
    public KeyCreationTimeModel? KeyCreationTime { get; set; }

    [JsonPropertyName("keyPolicy")]
    public KeyPolicyModel? KeyPolicy { get; set; }

    [JsonPropertyName("largeFileSharesState")]
    public LargeFileSharesStateConstant? LargeFileSharesState { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastGeoFailoverTime")]
    public DateTime? LastGeoFailoverTime { get; set; }

    [JsonPropertyName("minimumTlsVersion")]
    public MinimumTlsVersionConstant? MinimumTlsVersion { get; set; }

    [JsonPropertyName("networkAcls")]
    public NetworkRuleSetModel? NetworkAcls { get; set; }

    [JsonPropertyName("primaryEndpoints")]
    public EndpointsModel? PrimaryEndpoints { get; set; }

    [JsonPropertyName("primaryLocation")]
    public string? PrimaryLocation { get; set; }

    [JsonPropertyName("privateEndpointConnections")]
    public List<PrivateEndpointConnectionModel>? PrivateEndpointConnections { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("routingPreference")]
    public RoutingPreferenceModel? RoutingPreference { get; set; }

    [JsonPropertyName("sasPolicy")]
    public SasPolicyModel? SasPolicy { get; set; }

    [JsonPropertyName("secondaryEndpoints")]
    public EndpointsModel? SecondaryEndpoints { get; set; }

    [JsonPropertyName("secondaryLocation")]
    public string? SecondaryLocation { get; set; }

    [JsonPropertyName("statusOfPrimary")]
    public AccountStatusConstant? StatusOfPrimary { get; set; }

    [JsonPropertyName("statusOfSecondary")]
    public AccountStatusConstant? StatusOfSecondary { get; set; }

    [JsonPropertyName("supportsHttpsTrafficOnly")]
    public bool? SupportsHttpsTrafficOnly { get; set; }
}
