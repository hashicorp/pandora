using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.VideoAnalyzer.v2021_05_01_preview.VideoAnalyzer;


internal class VideoFlagsModel
{
    [JsonPropertyName("canStream")]
    [Required]
    public bool CanStream { get; set; }

    [JsonPropertyName("hasData")]
    [Required]
    public bool HasData { get; set; }

    [JsonPropertyName("isRecording")]
    [Required]
    public bool IsRecording { get; set; }
}
