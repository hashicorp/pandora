using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.VirtualMachineScaleSets;


internal class VirtualMachineScaleSetUpdateOSDiskModel
{
    [JsonPropertyName("caching")]
    public CachingTypesConstant? Caching { get; set; }

    [JsonPropertyName("diskSizeGB")]
    public int? DiskSizeGB { get; set; }

    [JsonPropertyName("image")]
    public VirtualHardDiskModel? Image { get; set; }

    [JsonPropertyName("managedDisk")]
    public VirtualMachineScaleSetManagedDiskParametersModel? ManagedDisk { get; set; }

    [JsonPropertyName("vhdContainers")]
    public List<string>? VhdContainers { get; set; }

    [JsonPropertyName("writeAcceleratorEnabled")]
    public bool? WriteAcceleratorEnabled { get; set; }
}
