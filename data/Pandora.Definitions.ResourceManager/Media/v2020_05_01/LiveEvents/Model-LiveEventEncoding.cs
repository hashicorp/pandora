using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2020_05_01.LiveEvents;


internal class LiveEventEncodingModel
{
    [JsonPropertyName("encodingType")]
    public LiveEventEncodingTypeConstant? EncodingType { get; set; }

    [JsonPropertyName("keyFrameInterval")]
    public string? KeyFrameInterval { get; set; }

    [JsonPropertyName("presetName")]
    public string? PresetName { get; set; }

    [JsonPropertyName("stretchMode")]
    public StretchModeConstant? StretchMode { get; set; }
}
