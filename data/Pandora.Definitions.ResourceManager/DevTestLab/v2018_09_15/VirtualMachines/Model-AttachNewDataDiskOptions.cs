using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.VirtualMachines;


internal class AttachNewDataDiskOptionsModel
{
    [JsonPropertyName("diskName")]
    public string? DiskName { get; set; }

    [JsonPropertyName("diskSizeGiB")]
    public int? DiskSizeGiB { get; set; }

    [JsonPropertyName("diskType")]
    public StorageTypeConstant? DiskType { get; set; }
}
