using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SystemCenterVirtualMachineManager.v2023_10_07.VirtualMachineInstances;


internal class HardwareProfileModel
{
    [JsonPropertyName("cpuCount")]
    public int? CpuCount { get; set; }

    [JsonPropertyName("dynamicMemoryEnabled")]
    public DynamicMemoryEnabledConstant? DynamicMemoryEnabled { get; set; }

    [JsonPropertyName("dynamicMemoryMaxMB")]
    public int? DynamicMemoryMaxMB { get; set; }

    [JsonPropertyName("dynamicMemoryMinMB")]
    public int? DynamicMemoryMinMB { get; set; }

    [JsonPropertyName("isHighlyAvailable")]
    public IsHighlyAvailableConstant? IsHighlyAvailable { get; set; }

    [JsonPropertyName("limitCpuForMigration")]
    public LimitCPUForMigrationConstant? LimitCPUForMigration { get; set; }

    [JsonPropertyName("memoryMB")]
    public int? MemoryMB { get; set; }
}
