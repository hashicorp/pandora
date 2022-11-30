using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2022_08_01.AssetsAndAssetFilters;

[ValueForType("#Microsoft.Media.AudioTrack")]
internal class AudioTrackModel : TrackBaseModel
{
    [JsonPropertyName("bitRate")]
    public int? BitRate { get; set; }

    [JsonPropertyName("dashSettings")]
    public DashSettingsModel? DashSettings { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("fileName")]
    public string? FileName { get; set; }

    [JsonPropertyName("hlsSettings")]
    public HlsSettingsModel? HlsSettings { get; set; }

    [JsonPropertyName("languageCode")]
    public string? LanguageCode { get; set; }

    [JsonPropertyName("mpeg4TrackId")]
    public int? Mpeg4TrackId { get; set; }
}
