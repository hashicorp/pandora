using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Workloads.v2023_04_01.SAPVirtualInstances;


internal class VirtualMachineResourceNamesModel
{
    [JsonPropertyName("dataDiskNames")]
    public Dictionary<string, List<string>>? DataDiskNames { get; set; }

    [JsonPropertyName("hostName")]
    public string? HostName { get; set; }

    [MaxItems(1)]
    [JsonPropertyName("networkInterfaces")]
    public List<NetworkInterfaceResourceNamesModel>? NetworkInterfaces { get; set; }

    [JsonPropertyName("osDiskName")]
    public string? OsDiskName { get; set; }

    [JsonPropertyName("vmName")]
    public string? VirtualMachineName { get; set; }
}
