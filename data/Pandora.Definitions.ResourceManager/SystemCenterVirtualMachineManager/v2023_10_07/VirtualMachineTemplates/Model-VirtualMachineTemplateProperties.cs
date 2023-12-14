using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SystemCenterVirtualMachineManager.v2023_10_07.VirtualMachineTemplates;


internal class VirtualMachineTemplatePropertiesModel
{
    [JsonPropertyName("computerName")]
    public string? ComputerName { get; set; }

    [JsonPropertyName("cpuCount")]
    public int? CpuCount { get; set; }

    [JsonPropertyName("disks")]
    public List<VirtualDiskModel>? Disks { get; set; }

    [JsonPropertyName("dynamicMemoryEnabled")]
    public DynamicMemoryEnabledConstant? DynamicMemoryEnabled { get; set; }

    [JsonPropertyName("dynamicMemoryMaxMB")]
    public int? DynamicMemoryMaxMB { get; set; }

    [JsonPropertyName("dynamicMemoryMinMB")]
    public int? DynamicMemoryMinMB { get; set; }

    [JsonPropertyName("generation")]
    public int? Generation { get; set; }

    [JsonPropertyName("inventoryItemId")]
    public string? InventoryItemId { get; set; }

    [JsonPropertyName("isCustomizable")]
    public IsCustomizableConstant? IsCustomizable { get; set; }

    [JsonPropertyName("isHighlyAvailable")]
    public IsHighlyAvailableConstant? IsHighlyAvailable { get; set; }

    [JsonPropertyName("limitCpuForMigration")]
    public LimitCPUForMigrationConstant? LimitCPUForMigration { get; set; }

    [JsonPropertyName("memoryMB")]
    public int? MemoryMB { get; set; }

    [JsonPropertyName("networkInterfaces")]
    public List<NetworkInterfaceModel>? NetworkInterfaces { get; set; }

    [JsonPropertyName("osName")]
    public string? OsName { get; set; }

    [JsonPropertyName("osType")]
    public OsTypeConstant? OsType { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("uuid")]
    public string? Uuid { get; set; }

    [JsonPropertyName("vmmServerId")]
    public string? VMmServerId { get; set; }
}
