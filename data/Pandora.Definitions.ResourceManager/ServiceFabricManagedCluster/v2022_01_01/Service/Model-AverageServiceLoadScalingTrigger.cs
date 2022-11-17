using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2022_01_01.Service;

[ValueForType("AverageServiceLoadTrigger")]
internal class AverageServiceLoadScalingTriggerModel : ScalingTriggerModel
{
    [JsonPropertyName("lowerLoadThreshold")]
    [Required]
    public float LowerLoadThreshold { get; set; }

    [JsonPropertyName("metricName")]
    [Required]
    public string MetricName { get; set; }

    [JsonPropertyName("scaleInterval")]
    [Required]
    public string ScaleInterval { get; set; }

    [JsonPropertyName("upperLoadThreshold")]
    [Required]
    public float UpperLoadThreshold { get; set; }

    [JsonPropertyName("useOnlyPrimaryLoad")]
    [Required]
    public bool UseOnlyPrimaryLoad { get; set; }
}
