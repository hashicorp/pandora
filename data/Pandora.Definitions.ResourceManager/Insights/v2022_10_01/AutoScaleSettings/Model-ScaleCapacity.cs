using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2022_10_01.AutoScaleSettings;


internal class ScaleCapacityModel
{
    [JsonPropertyName("default")]
    [Required]
    public string Default { get; set; }

    [JsonPropertyName("maximum")]
    [Required]
    public string Maximum { get; set; }

    [JsonPropertyName("minimum")]
    [Required]
    public string Minimum { get; set; }
}
