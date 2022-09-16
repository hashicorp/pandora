using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_07_01.DedicatedHosts;


internal class DedicatedHostAllocatableVMModel
{
    [JsonPropertyName("count")]
    public float? Count { get; set; }

    [JsonPropertyName("vmSize")]
    public string? VmSize { get; set; }
}
