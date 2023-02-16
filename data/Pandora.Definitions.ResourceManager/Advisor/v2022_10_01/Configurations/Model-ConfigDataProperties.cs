using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Advisor.v2022_10_01.Configurations;


internal class ConfigDataPropertiesModel
{
    [JsonPropertyName("digests")]
    public List<DigestConfigModel>? Digests { get; set; }

    [JsonPropertyName("duration")]
    public DurationConstant? Duration { get; set; }

    [JsonPropertyName("exclude")]
    public bool? Exclude { get; set; }

    [JsonPropertyName("lowCpuThreshold")]
    public CPUThresholdConstant? LowCPUThreshold { get; set; }
}
