using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.VirtualMachines;


internal class DataDiskModel
{
    [JsonPropertyName("caching")]
    public CachingTypesConstant? Caching { get; set; }

    [JsonPropertyName("createOption")]
    [Required]
    public DiskCreateOptionTypesConstant CreateOption { get; set; }

    [JsonPropertyName("deleteOption")]
    public DiskDeleteOptionTypesConstant? DeleteOption { get; set; }

    [JsonPropertyName("detachOption")]
    public DiskDetachOptionTypesConstant? DetachOption { get; set; }

    [JsonPropertyName("diskIOPSReadWrite")]
    public int? DiskIOPSReadWrite { get; set; }

    [JsonPropertyName("diskMBpsReadWrite")]
    public int? DiskMBpsReadWrite { get; set; }

    [JsonPropertyName("diskSizeGB")]
    public int? DiskSizeGB { get; set; }

    [JsonPropertyName("image")]
    public VirtualHardDiskModel? Image { get; set; }

    [JsonPropertyName("lun")]
    [Required]
    public int Lun { get; set; }

    [JsonPropertyName("managedDisk")]
    public ManagedDiskParametersModel? ManagedDisk { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("toBeDetached")]
    public bool? ToBeDetached { get; set; }

    [JsonPropertyName("vhd")]
    public VirtualHardDiskModel? Vhd { get; set; }

    [JsonPropertyName("writeAcceleratorEnabled")]
    public bool? WriteAcceleratorEnabled { get; set; }
}
