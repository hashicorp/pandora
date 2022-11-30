using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2021_11_01.Encodings;


internal class H265LayerModel
{
    [JsonPropertyName("adaptiveBFrame")]
    public bool? AdaptiveBFrame { get; set; }

    [JsonPropertyName("bFrames")]
    public int? BFrames { get; set; }

    [JsonPropertyName("bitrate")]
    [Required]
    public int Bitrate { get; set; }

    [JsonPropertyName("bufferWindow")]
    public string? BufferWindow { get; set; }

    [JsonPropertyName("crf")]
    public float? Crf { get; set; }

    [JsonPropertyName("frameRate")]
    public string? FrameRate { get; set; }

    [JsonPropertyName("height")]
    public string? Height { get; set; }

    [JsonPropertyName("label")]
    public string? Label { get; set; }

    [JsonPropertyName("level")]
    public string? Level { get; set; }

    [JsonPropertyName("maxBitrate")]
    public int? MaxBitrate { get; set; }

    [JsonPropertyName("profile")]
    public H265VideoProfileConstant? Profile { get; set; }

    [JsonPropertyName("referenceFrames")]
    public int? ReferenceFrames { get; set; }

    [JsonPropertyName("slices")]
    public int? Slices { get; set; }

    [JsonPropertyName("width")]
    public string? Width { get; set; }
}
