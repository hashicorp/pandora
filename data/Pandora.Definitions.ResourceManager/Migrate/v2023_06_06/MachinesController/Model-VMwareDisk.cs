using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.MachinesController;


internal class VMwareDiskModel
{
    [JsonPropertyName("controllerType")]
    public string? ControllerType { get; set; }

    [JsonPropertyName("diskMode")]
    public string? DiskMode { get; set; }

    [JsonPropertyName("diskProvisioningPolicy")]
    public string? DiskProvisioningPolicy { get; set; }

    [JsonPropertyName("diskScrubbingPolicy")]
    public string? DiskScrubbingPolicy { get; set; }

    [JsonPropertyName("diskType")]
    public string? DiskType { get; set; }

    [JsonPropertyName("label")]
    public string? Label { get; set; }

    [JsonPropertyName("lun")]
    public int? Lun { get; set; }

    [JsonPropertyName("maxSizeInBytes")]
    public int? MaxSizeInBytes { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("path")]
    public string? Path { get; set; }

    [JsonPropertyName("uuid")]
    public string? Uuid { get; set; }
}
