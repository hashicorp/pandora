using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HDInsight.v2021_06_01.Regions;


internal class VMSizePropertyModel
{
    [JsonPropertyName("cores")]
    public int? Cores { get; set; }

    [JsonPropertyName("dataDiskStorageTier")]
    public string? DataDiskStorageTier { get; set; }

    [JsonPropertyName("label")]
    public string? Label { get; set; }

    [JsonPropertyName("maxDataDiskCount")]
    public int? MaxDataDiskCount { get; set; }

    [JsonPropertyName("memoryInMb")]
    public int? MemoryInMb { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("supportedByVirtualMachines")]
    public bool? SupportedByVirtualMachines { get; set; }

    [JsonPropertyName("supportedByWebWorkerRoles")]
    public bool? SupportedByWebWorkerRoles { get; set; }

    [JsonPropertyName("virtualMachineResourceDiskSizeInMb")]
    public int? VirtualMachineResourceDiskSizeInMb { get; set; }

    [JsonPropertyName("webWorkerResourceDiskSizeInMb")]
    public int? WebWorkerResourceDiskSizeInMb { get; set; }
}
