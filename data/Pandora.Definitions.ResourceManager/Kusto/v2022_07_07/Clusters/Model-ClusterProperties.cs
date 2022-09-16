using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Kusto.v2022_07_07.Clusters;


internal class ClusterPropertiesModel
{
    [JsonPropertyName("acceptedAudiences")]
    public List<AcceptedAudiencesModel>? AcceptedAudiences { get; set; }

    [JsonPropertyName("allowedFqdnList")]
    public List<string>? AllowedFqdnList { get; set; }

    [JsonPropertyName("allowedIpRangeList")]
    public List<string>? AllowedIPRangeList { get; set; }

    [JsonPropertyName("dataIngestionUri")]
    public string? DataIngestionUri { get; set; }

    [JsonPropertyName("enableAutoStop")]
    public bool? EnableAutoStop { get; set; }

    [JsonPropertyName("enableDiskEncryption")]
    public bool? EnableDiskEncryption { get; set; }

    [JsonPropertyName("enableDoubleEncryption")]
    public bool? EnableDoubleEncryption { get; set; }

    [JsonPropertyName("enablePurge")]
    public bool? EnablePurge { get; set; }

    [JsonPropertyName("enableStreamingIngest")]
    public bool? EnableStreamingIngest { get; set; }

    [JsonPropertyName("engineType")]
    public EngineTypeConstant? EngineType { get; set; }

    [JsonPropertyName("keyVaultProperties")]
    public KeyVaultPropertiesModel? KeyVaultProperties { get; set; }

    [JsonPropertyName("languageExtensions")]
    public LanguageExtensionsListModel? LanguageExtensions { get; set; }

    [JsonPropertyName("optimizedAutoscale")]
    public OptimizedAutoscaleModel? OptimizedAutoscale { get; set; }

    [JsonPropertyName("privateEndpointConnections")]
    public List<PrivateEndpointConnectionModel>? PrivateEndpointConnections { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("publicIPType")]
    public PublicIPTypeConstant? PublicIPType { get; set; }

    [JsonPropertyName("publicNetworkAccess")]
    public PublicNetworkAccessConstant? PublicNetworkAccess { get; set; }

    [JsonPropertyName("restrictOutboundNetworkAccess")]
    public ClusterNetworkAccessFlagConstant? RestrictOutboundNetworkAccess { get; set; }

    [JsonPropertyName("state")]
    public StateConstant? State { get; set; }

    [JsonPropertyName("stateReason")]
    public string? StateReason { get; set; }

    [JsonPropertyName("trustedExternalTenants")]
    public List<TrustedExternalTenantModel>? TrustedExternalTenants { get; set; }

    [JsonPropertyName("uri")]
    public string? Uri { get; set; }

    [JsonPropertyName("virtualClusterGraduationProperties")]
    public string? VirtualClusterGraduationProperties { get; set; }

    [JsonPropertyName("virtualNetworkConfiguration")]
    public VirtualNetworkConfigurationModel? VirtualNetworkConfiguration { get; set; }
}
