using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;


internal class RackDefinitionModel
{
    [JsonPropertyName("availabilityZone")]
    public CustomTypes.Zone? AvailabilityZone { get; set; }

    [JsonPropertyName("bareMetalMachineConfigurationData")]
    public List<BareMetalMachineConfigurationDataModel>? BareMetalMachineConfigurationData { get; set; }

    [JsonPropertyName("networkRackId")]
    [Required]
    public string NetworkRackId { get; set; }

    [JsonPropertyName("rackLocation")]
    public string? RackLocation { get; set; }

    [JsonPropertyName("rackSerialNumber")]
    [Required]
    public string RackSerialNumber { get; set; }

    [JsonPropertyName("rackSkuId")]
    [Required]
    public string RackSkuId { get; set; }

    [JsonPropertyName("storageApplianceConfigurationData")]
    public List<StorageApplianceConfigurationDataModel>? StorageApplianceConfigurationData { get; set; }
}
