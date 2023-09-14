using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.ImportMachinesController;


internal class WebRoleImportDiskModel
{
    [JsonPropertyName("diskType")]
    public string? DiskType { get; set; }

    [JsonPropertyName("lun")]
    public int? Lun { get; set; }

    [JsonPropertyName("maxSizeInBytes")]
    public int? MaxSizeInBytes { get; set; }

    [JsonPropertyName("megabytesPerSecondOfRead")]
    public float? MegabytesPerSecondOfRead { get; set; }

    [JsonPropertyName("megabytesPerSecondOfWrite")]
    public float? MegabytesPerSecondOfWrite { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("numberOfReadOperationsPerSecond")]
    public float? NumberOfReadOperationsPerSecond { get; set; }

    [JsonPropertyName("numberOfWriteOperationsPerSecond")]
    public float? NumberOfWriteOperationsPerSecond { get; set; }

    [JsonPropertyName("path")]
    public string? Path { get; set; }
}
