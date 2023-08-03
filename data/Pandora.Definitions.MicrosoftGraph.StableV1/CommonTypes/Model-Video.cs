// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class VideoModel
{
    [JsonPropertyName("audioBitsPerSample")]
    public int? AudioBitsPerSample { get; set; }

    [JsonPropertyName("audioChannels")]
    public int? AudioChannels { get; set; }

    [JsonPropertyName("audioFormat")]
    public string? AudioFormat { get; set; }

    [JsonPropertyName("audioSamplesPerSecond")]
    public int? AudioSamplesPerSecond { get; set; }

    [JsonPropertyName("bitrate")]
    public int? Bitrate { get; set; }

    [JsonPropertyName("duration")]
    public long? Duration { get; set; }

    [JsonPropertyName("fourCC")]
    public string? FourCC { get; set; }

    [JsonPropertyName("height")]
    public int? Height { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("width")]
    public int? Width { get; set; }
}
