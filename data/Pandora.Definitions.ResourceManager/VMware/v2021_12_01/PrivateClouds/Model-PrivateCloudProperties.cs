using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.VMware.v2021_12_01.PrivateClouds;


internal class PrivateCloudPropertiesModel
{
    [JsonPropertyName("availability")]
    public AvailabilityPropertiesModel? Availability { get; set; }

    [JsonPropertyName("circuit")]
    public CircuitModel? Circuit { get; set; }

    [JsonPropertyName("encryption")]
    public EncryptionModel? Encryption { get; set; }

    [JsonPropertyName("endpoints")]
    public EndpointsModel? Endpoints { get; set; }

    [JsonPropertyName("externalCloudLinks")]
    public List<string>? ExternalCloudLinks { get; set; }

    [JsonPropertyName("identitySources")]
    public List<IdentitySourceModel>? IdentitySources { get; set; }

    [JsonPropertyName("internet")]
    public InternetEnumConstant? Internet { get; set; }

    [JsonPropertyName("managementCluster")]
    [Required]
    public CommonClusterPropertiesModel ManagementCluster { get; set; }

    [JsonPropertyName("managementNetwork")]
    public string? ManagementNetwork { get; set; }

    [JsonPropertyName("networkBlock")]
    [Required]
    public string NetworkBlock { get; set; }

    [JsonPropertyName("nsxtCertificateThumbprint")]
    public string? NsxtCertificateThumbprint { get; set; }

    [JsonPropertyName("nsxtPassword")]
    public string? NsxtPassword { get; set; }

    [JsonPropertyName("provisioningNetwork")]
    public string? ProvisioningNetwork { get; set; }

    [JsonPropertyName("provisioningState")]
    public PrivateCloudProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("secondaryCircuit")]
    public CircuitModel? SecondaryCircuit { get; set; }

    [JsonPropertyName("vcenterCertificateThumbprint")]
    public string? VcenterCertificateThumbprint { get; set; }

    [JsonPropertyName("vcenterPassword")]
    public string? VcenterPassword { get; set; }

    [JsonPropertyName("vmotionNetwork")]
    public string? VmotionNetwork { get; set; }
}
