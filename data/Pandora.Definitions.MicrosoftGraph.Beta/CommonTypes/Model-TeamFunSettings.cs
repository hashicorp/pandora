// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class TeamFunSettingsModel
{
    [JsonPropertyName("allowCustomMemes")]
    public bool? AllowCustomMemes { get; set; }

    [JsonPropertyName("allowGiphy")]
    public bool? AllowGiphy { get; set; }

    [JsonPropertyName("allowStickersAndMemes")]
    public bool? AllowStickersAndMemes { get; set; }

    [JsonPropertyName("giphyContentRating")]
    public GiphyRatingTypeConstant? GiphyContentRating { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
