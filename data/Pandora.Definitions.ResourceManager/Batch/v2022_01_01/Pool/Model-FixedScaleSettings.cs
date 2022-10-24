using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Batch.v2022_01_01.Pool;


internal class FixedScaleSettingsModel
{
    [JsonPropertyName("nodeDeallocationOption")]
    public ComputeNodeDeallocationOptionConstant? NodeDeallocationOption { get; set; }

    [JsonPropertyName("resizeTimeout")]
    public string? ResizeTimeout { get; set; }

    [JsonPropertyName("targetDedicatedNodes")]
    public int? TargetDedicatedNodes { get; set; }

    [JsonPropertyName("targetLowPriorityNodes")]
    public int? TargetLowPriorityNodes { get; set; }
}
