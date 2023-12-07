using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Batch.v2023_11_01.Pool;


internal class OSDiskModel
{
    [JsonPropertyName("caching")]
    public CachingTypeConstant? Caching { get; set; }

    [JsonPropertyName("diskSizeGB")]
    public int? DiskSizeGB { get; set; }

    [JsonPropertyName("ephemeralOSDiskSettings")]
    public DiffDiskSettingsModel? EphemeralOSDiskSettings { get; set; }

    [JsonPropertyName("managedDisk")]
    public ManagedDiskModel? ManagedDisk { get; set; }

    [JsonPropertyName("writeAcceleratorEnabled")]
    public bool? WriteAcceleratorEnabled { get; set; }
}
