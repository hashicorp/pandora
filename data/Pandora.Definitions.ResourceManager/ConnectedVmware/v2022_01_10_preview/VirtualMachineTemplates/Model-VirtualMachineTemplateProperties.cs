using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2022_01_10_preview.VirtualMachineTemplates;


internal class VirtualMachineTemplatePropertiesModel
{
    [JsonPropertyName("customResourceName")]
    public string? CustomResourceName { get; set; }

    [JsonPropertyName("disks")]
    public List<VirtualDiskModel>? Disks { get; set; }

    [JsonPropertyName("firmwareType")]
    public FirmwareTypeConstant? FirmwareType { get; set; }

    [JsonPropertyName("folderPath")]
    public string? FolderPath { get; set; }

    [JsonPropertyName("inventoryItemId")]
    public string? InventoryItemId { get; set; }

    [JsonPropertyName("memorySizeMB")]
    public int? MemorySizeMB { get; set; }

    [JsonPropertyName("moName")]
    public string? MoName { get; set; }

    [JsonPropertyName("moRefId")]
    public string? MoRefId { get; set; }

    [JsonPropertyName("networkInterfaces")]
    public List<NetworkInterfaceModel>? NetworkInterfaces { get; set; }

    [JsonPropertyName("numCPUs")]
    public int? NumCPUs { get; set; }

    [JsonPropertyName("numCoresPerSocket")]
    public int? NumCoresPerSocket { get; set; }

    [JsonPropertyName("osName")]
    public string? OsName { get; set; }

    [JsonPropertyName("osType")]
    public OsTypeConstant? OsType { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("statuses")]
    public List<ResourceStatusModel>? Statuses { get; set; }

    [JsonPropertyName("toolsVersion")]
    public string? ToolsVersion { get; set; }

    [JsonPropertyName("toolsVersionStatus")]
    public string? ToolsVersionStatus { get; set; }

    [JsonPropertyName("uuid")]
    public string? Uuid { get; set; }

    [JsonPropertyName("vCenterId")]
    public string? VCenterId { get; set; }
}
