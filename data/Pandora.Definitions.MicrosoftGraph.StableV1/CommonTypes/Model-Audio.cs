// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class AudioModel
{
    [JsonPropertyName("album")]
    public string? Album { get; set; }

    [JsonPropertyName("albumArtist")]
    public string? AlbumArtist { get; set; }

    [JsonPropertyName("artist")]
    public string? Artist { get; set; }

    [JsonPropertyName("bitrate")]
    public long? Bitrate { get; set; }

    [JsonPropertyName("composers")]
    public string? Composers { get; set; }

    [JsonPropertyName("copyright")]
    public string? Copyright { get; set; }

    [JsonPropertyName("disc")]
    public short? Disc { get; set; }

    [JsonPropertyName("discCount")]
    public short? DiscCount { get; set; }

    [JsonPropertyName("duration")]
    public long? Duration { get; set; }

    [JsonPropertyName("genre")]
    public string? Genre { get; set; }

    [JsonPropertyName("hasDrm")]
    public bool? HasDrm { get; set; }

    [JsonPropertyName("isVariableBitrate")]
    public bool? IsVariableBitrate { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("track")]
    public int? Track { get; set; }

    [JsonPropertyName("trackCount")]
    public int? TrackCount { get; set; }

    [JsonPropertyName("year")]
    public int? Year { get; set; }
}
