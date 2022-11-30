using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2021_11_01.Encodings;


internal class PresetConfigurationsModel
{
    [JsonPropertyName("complexity")]
    public ComplexityConstant? Complexity { get; set; }

    [JsonPropertyName("interleaveOutput")]
    public InterleaveOutputConstant? InterleaveOutput { get; set; }

    [JsonPropertyName("keyFrameIntervalInSeconds")]
    public float? KeyFrameIntervalInSeconds { get; set; }

    [JsonPropertyName("maxBitrateBps")]
    public int? MaxBitrateBps { get; set; }

    [JsonPropertyName("maxHeight")]
    public int? MaxHeight { get; set; }

    [JsonPropertyName("maxLayers")]
    public int? MaxLayers { get; set; }

    [JsonPropertyName("minBitrateBps")]
    public int? MinBitrateBps { get; set; }

    [JsonPropertyName("minHeight")]
    public int? MinHeight { get; set; }
}
