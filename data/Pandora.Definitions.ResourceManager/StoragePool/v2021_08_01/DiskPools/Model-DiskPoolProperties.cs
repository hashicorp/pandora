using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.StoragePool.v2021_08_01.DiskPools;


internal class DiskPoolPropertiesModel
{
    [JsonPropertyName("additionalCapabilities")]
    public List<string>? AdditionalCapabilities { get; set; }

    [JsonPropertyName("availabilityZones")]
    [Required]
    public List<string> AvailabilityZones { get; set; }

    [JsonPropertyName("disks")]
    public List<DiskModel>? Disks { get; set; }

    [JsonPropertyName("provisioningState")]
    [Required]
    public ProvisioningStatesConstant ProvisioningState { get; set; }

    [JsonPropertyName("status")]
    [Required]
    public OperationalStatusConstant Status { get; set; }

    [JsonPropertyName("subnetId")]
    [Required]
    public string SubnetId { get; set; }
}
