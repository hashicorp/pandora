using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2021_05_01.NodeType;


internal class NodeTypePropertiesModel
{
    [JsonPropertyName("applicationPorts")]
    public EndpointRangeDescriptionModel? ApplicationPorts { get; set; }

    [JsonPropertyName("capacities")]
    public Dictionary<string, string>? Capacities { get; set; }

    [JsonPropertyName("dataDiskSizeGB")]
    [Required]
    public int DataDiskSizeGB { get; set; }

    [JsonPropertyName("dataDiskType")]
    public DiskTypeConstant? DataDiskType { get; set; }

    [JsonPropertyName("ephemeralPorts")]
    public EndpointRangeDescriptionModel? EphemeralPorts { get; set; }

    [JsonPropertyName("isPrimary")]
    [Required]
    public bool IsPrimary { get; set; }

    [JsonPropertyName("isStateless")]
    public bool? IsStateless { get; set; }

    [JsonPropertyName("multiplePlacementGroups")]
    public bool? MultiplePlacementGroups { get; set; }

    [JsonPropertyName("placementProperties")]
    public Dictionary<string, string>? PlacementProperties { get; set; }

    [JsonPropertyName("provisioningState")]
    public ManagedResourceProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("vmExtensions")]
    public List<VMSSExtensionModel>? VmExtensions { get; set; }

    [JsonPropertyName("vmImageOffer")]
    public string? VmImageOffer { get; set; }

    [JsonPropertyName("vmImagePublisher")]
    public string? VmImagePublisher { get; set; }

    [JsonPropertyName("vmImageSku")]
    public string? VmImageSku { get; set; }

    [JsonPropertyName("vmImageVersion")]
    public string? VmImageVersion { get; set; }

    [JsonPropertyName("vmInstanceCount")]
    [Required]
    public int VmInstanceCount { get; set; }

    [JsonPropertyName("vmManagedIdentity")]
    public CustomTypes.UserAssignedIdentityList? VmManagedIdentity { get; set; }

    [JsonPropertyName("vmSecrets")]
    public List<VaultSecretGroupModel>? VmSecrets { get; set; }

    [JsonPropertyName("vmSize")]
    public string? VmSize { get; set; }
}
