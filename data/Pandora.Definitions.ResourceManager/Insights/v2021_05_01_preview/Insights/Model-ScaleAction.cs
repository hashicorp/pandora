using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2021_05_01_preview.Insights;


internal class ScaleActionModel
{
    [JsonPropertyName("cooldown")]
    [Required]
    public string Cooldown { get; set; }

    [JsonPropertyName("direction")]
    [Required]
    public ScaleDirectionConstant Direction { get; set; }

    [JsonPropertyName("type")]
    [Required]
    public ScaleTypeConstant Type { get; set; }

    [JsonPropertyName("value")]
    public string? Value { get; set; }
}
