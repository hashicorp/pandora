using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;


internal class MachineSkuPropertiesModel
{
    [JsonPropertyName("bootstrapProtocol")]
    public BootstrapProtocolConstant? BootstrapProtocol { get; set; }

    [JsonPropertyName("cpuCores")]
    public int? CpuCores { get; set; }

    [JsonPropertyName("cpuSockets")]
    public int? CpuSockets { get; set; }

    [JsonPropertyName("disks")]
    public List<MachineDiskModel>? Disks { get; set; }

    [JsonPropertyName("generation")]
    public string? Generation { get; set; }

    [JsonPropertyName("hardwareVersion")]
    public string? HardwareVersion { get; set; }

    [JsonPropertyName("memoryCapacityGB")]
    public int? MemoryCapacityGB { get; set; }

    [JsonPropertyName("model")]
    public string? Model { get; set; }

    [JsonPropertyName("networkInterfaces")]
    public List<NetworkInterfaceModel>? NetworkInterfaces { get; set; }

    [JsonPropertyName("totalThreads")]
    public int? TotalThreads { get; set; }

    [JsonPropertyName("vendor")]
    public string? Vendor { get; set; }
}
