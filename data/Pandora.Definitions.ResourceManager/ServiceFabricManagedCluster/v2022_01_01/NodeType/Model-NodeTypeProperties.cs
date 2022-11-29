using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2022_01_01.NodeType;


internal class NodeTypePropertiesModel
{
    [JsonPropertyName("additionalDataDisks")]
    public List<VMSSDataDiskModel>? AdditionalDataDisks { get; set; }

    [JsonPropertyName("applicationPorts")]
    public EndpointRangeDescriptionModel? ApplicationPorts { get; set; }

    [JsonPropertyName("capacities")]
    public Dictionary<string, string>? Capacities { get; set; }

    [JsonPropertyName("dataDiskLetter")]
    public string? DataDiskLetter { get; set; }

    [JsonPropertyName("dataDiskSizeGB")]
    public int? DataDiskSizeGB { get; set; }

    [JsonPropertyName("dataDiskType")]
    public DiskTypeConstant? DataDiskType { get; set; }

    [JsonPropertyName("enableAcceleratedNetworking")]
    public bool? EnableAcceleratedNetworking { get; set; }

    [JsonPropertyName("enableEncryptionAtHost")]
    public bool? EnableEncryptionAtHost { get; set; }

    [JsonPropertyName("enableOverProvisioning")]
    public bool? EnableOverProvisioning { get; set; }

    [JsonPropertyName("ephemeralPorts")]
    public EndpointRangeDescriptionModel? EphemeralPorts { get; set; }

    [JsonPropertyName("frontendConfigurations")]
    public List<FrontendConfigurationModel>? FrontendConfigurations { get; set; }

    [JsonPropertyName("isPrimary")]
    [Required]
    public bool IsPrimary { get; set; }

    [JsonPropertyName("isStateless")]
    public bool? IsStateless { get; set; }

    [JsonPropertyName("multiplePlacementGroups")]
    public bool? MultiplePlacementGroups { get; set; }

    [JsonPropertyName("networkSecurityRules")]
    public List<NetworkSecurityRuleModel>? NetworkSecurityRules { get; set; }

    [JsonPropertyName("placementProperties")]
    public Dictionary<string, string>? PlacementProperties { get; set; }

    [JsonPropertyName("provisioningState")]
    public ManagedResourceProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("useDefaultPublicLoadBalancer")]
    public bool? UseDefaultPublicLoadBalancer { get; set; }

    [JsonPropertyName("useTempDataDisk")]
    public bool? UseTempDataDisk { get; set; }

    [JsonPropertyName("vmExtensions")]
    public List<VMSSExtensionModel>? VMExtensions { get; set; }

    [JsonPropertyName("vmImageOffer")]
    public string? VMImageOffer { get; set; }

    [JsonPropertyName("vmImagePublisher")]
    public string? VMImagePublisher { get; set; }

    [JsonPropertyName("vmImageSku")]
    public string? VMImageSku { get; set; }

    [JsonPropertyName("vmImageVersion")]
    public string? VMImageVersion { get; set; }

    [JsonPropertyName("vmInstanceCount")]
    [Required]
    public int VMInstanceCount { get; set; }

    [JsonPropertyName("vmManagedIdentity")]
    public CustomTypes.UserAssignedIdentityList? VMManagedIdentity { get; set; }

    [JsonPropertyName("vmSecrets")]
    public List<VaultSecretGroupModel>? VMSecrets { get; set; }

    [JsonPropertyName("vmSize")]
    public string? VMSize { get; set; }
}
