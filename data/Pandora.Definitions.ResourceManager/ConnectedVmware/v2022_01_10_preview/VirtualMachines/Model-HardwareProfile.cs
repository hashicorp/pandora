using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2022_01_10_preview.VirtualMachines;


internal class HardwareProfileModel
{
    [JsonPropertyName("cpuHotAddEnabled")]
    public bool? CpuHotAddEnabled { get; set; }

    [JsonPropertyName("cpuHotRemoveEnabled")]
    public bool? CpuHotRemoveEnabled { get; set; }

    [JsonPropertyName("memoryHotAddEnabled")]
    public bool? MemoryHotAddEnabled { get; set; }

    [JsonPropertyName("memorySizeMB")]
    public int? MemorySizeMB { get; set; }

    [JsonPropertyName("numCPUs")]
    public int? NumCPUs { get; set; }

    [JsonPropertyName("numCoresPerSocket")]
    public int? NumCoresPerSocket { get; set; }
}
