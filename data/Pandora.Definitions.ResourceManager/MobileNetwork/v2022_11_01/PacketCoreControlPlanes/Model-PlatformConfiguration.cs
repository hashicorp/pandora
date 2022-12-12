using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2022_11_01.PacketCoreControlPlanes;


internal class PlatformConfigurationModel
{
    [JsonPropertyName("azureStackEdgeDevice")]
    public AzureStackEdgeDeviceResourceIdModel? AzureStackEdgeDevice { get; set; }

    [JsonPropertyName("azureStackEdgeDevices")]
    public List<AzureStackEdgeDeviceResourceIdModel>? AzureStackEdgeDevices { get; set; }

    [JsonPropertyName("azureStackHciCluster")]
    public AzureStackHCIClusterResourceIdModel? AzureStackHciCluster { get; set; }

    [JsonPropertyName("connectedCluster")]
    public ConnectedClusterResourceIdModel? ConnectedCluster { get; set; }

    [JsonPropertyName("customLocation")]
    public CustomLocationResourceIdModel? CustomLocation { get; set; }

    [JsonPropertyName("type")]
    [Required]
    public PlatformTypeConstant Type { get; set; }
}
