// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ThumbnailSetModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("large")]
    public ThumbnailModel? Large { get; set; }

    [JsonPropertyName("medium")]
    public ThumbnailModel? Medium { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("small")]
    public ThumbnailModel? Small { get; set; }

    [JsonPropertyName("source")]
    public ThumbnailModel? Source { get; set; }
}
