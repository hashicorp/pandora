using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2022_01_10_preview.InventoryItems;

[ValueForType("VirtualMachine")]
internal class VirtualMachineInventoryItemModel : InventoryItemPropertiesModel
{
    [JsonPropertyName("folderPath")]
    public string? FolderPath { get; set; }

    [JsonPropertyName("host")]
    public InventoryItemDetailsModel? Host { get; set; }

    [JsonPropertyName("ipAddresses")]
    public List<string>? IPAddresses { get; set; }

    [JsonPropertyName("instanceUuid")]
    public string? InstanceUuid { get; set; }

    [JsonPropertyName("osName")]
    public string? OsName { get; set; }

    [JsonPropertyName("osType")]
    public OsTypeConstant? OsType { get; set; }

    [JsonPropertyName("powerState")]
    public string? PowerState { get; set; }

    [JsonPropertyName("resourcePool")]
    public InventoryItemDetailsModel? ResourcePool { get; set; }

    [JsonPropertyName("smbiosUuid")]
    public string? SmbiosUuid { get; set; }

    [JsonPropertyName("toolsRunningStatus")]
    public string? ToolsRunningStatus { get; set; }

    [JsonPropertyName("toolsVersion")]
    public string? ToolsVersion { get; set; }

    [JsonPropertyName("toolsVersionStatus")]
    public string? ToolsVersionStatus { get; set; }
}
