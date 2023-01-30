using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2020_12_01.Roles;


internal class KubernetesRoleComputeModel
{
    [JsonPropertyName("memoryInBytes")]
    public int? MemoryInBytes { get; set; }

    [JsonPropertyName("processorCount")]
    public int? ProcessorCount { get; set; }

    [JsonPropertyName("vmProfile")]
    [Required]
    public string VMProfile { get; set; }
}
