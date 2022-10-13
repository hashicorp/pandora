using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2022_01_10_preview.VirtualMachines;


internal class VirtualDiskModel
{
    [JsonPropertyName("controllerKey")]
    public int? ControllerKey { get; set; }

    [JsonPropertyName("deviceKey")]
    public int? DeviceKey { get; set; }

    [JsonPropertyName("deviceName")]
    public string? DeviceName { get; set; }

    [JsonPropertyName("diskMode")]
    public DiskModeConstant? DiskMode { get; set; }

    [JsonPropertyName("diskObjectId")]
    public string? DiskObjectId { get; set; }

    [JsonPropertyName("diskSizeGB")]
    public int? DiskSizeGB { get; set; }

    [JsonPropertyName("diskType")]
    public DiskTypeConstant? DiskType { get; set; }

    [JsonPropertyName("label")]
    public string? Label { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("unitNumber")]
    public int? UnitNumber { get; set; }
}
