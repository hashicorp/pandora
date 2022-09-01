using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerInstance.v2021_10_01.ContainerInstance;


internal class ResourceRequestsModel
{
    [JsonPropertyName("cpu")]
    [Required]
    public float Cpu { get; set; }

    [JsonPropertyName("gpu")]
    public GpuResourceModel? Gpu { get; set; }

    [JsonPropertyName("memoryInGB")]
    [Required]
    public float MemoryInGB { get; set; }
}
