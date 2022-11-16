using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2020_05_01.Encodings;

[ValueForType("#Microsoft.Media.VideoAnalyzerPreset")]
internal class VideoAnalyzerPresetModel : PresetModel
{
    [JsonPropertyName("audioLanguage")]
    public string? AudioLanguage { get; set; }

    [JsonPropertyName("experimentalOptions")]
    public Dictionary<string, string>? ExperimentalOptions { get; set; }

    [JsonPropertyName("insightsToExtract")]
    public InsightsTypeConstant? InsightsToExtract { get; set; }

    [JsonPropertyName("mode")]
    public AudioAnalysisModeConstant? Mode { get; set; }
}
