using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.VirtualMachines;


internal class VirtualMachineSizeModel
{
    [JsonPropertyName("maxDataDiskCount")]
    public int? MaxDataDiskCount { get; set; }

    [JsonPropertyName("memoryInMB")]
    public int? MemoryInMB { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("numberOfCores")]
    public int? NumberOfCores { get; set; }

    [JsonPropertyName("osDiskSizeInMB")]
    public int? OsDiskSizeInMB { get; set; }

    [JsonPropertyName("resourceDiskSizeInMB")]
    public int? ResourceDiskSizeInMB { get; set; }
}
