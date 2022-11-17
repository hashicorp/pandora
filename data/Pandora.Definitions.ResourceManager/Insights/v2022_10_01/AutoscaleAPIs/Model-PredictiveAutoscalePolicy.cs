using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2022_10_01.AutoscaleAPIs;


internal class PredictiveAutoscalePolicyModel
{
    [JsonPropertyName("scaleLookAheadTime")]
    public string? ScaleLookAheadTime { get; set; }

    [JsonPropertyName("scaleMode")]
    [Required]
    public PredictiveAutoscalePolicyScaleModeConstant ScaleMode { get; set; }
}
