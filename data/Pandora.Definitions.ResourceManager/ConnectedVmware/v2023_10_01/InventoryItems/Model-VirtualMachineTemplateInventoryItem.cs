using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2023_10_01.InventoryItems;

[ValueForType("VirtualMachineTemplate")]
internal class VirtualMachineTemplateInventoryItemModel : InventoryItemPropertiesModel
{
    [JsonPropertyName("folderPath")]
    public string? FolderPath { get; set; }

    [JsonPropertyName("memorySizeMB")]
    public int? MemorySizeMB { get; set; }

    [JsonPropertyName("numCPUs")]
    public int? NumCPUs { get; set; }

    [JsonPropertyName("numCoresPerSocket")]
    public int? NumCoresPerSocket { get; set; }

    [JsonPropertyName("osName")]
    public string? OsName { get; set; }

    [JsonPropertyName("osType")]
    public OsTypeConstant? OsType { get; set; }

    [JsonPropertyName("toolsVersion")]
    public string? ToolsVersion { get; set; }

    [JsonPropertyName("toolsVersionStatus")]
    public string? ToolsVersionStatus { get; set; }
}
