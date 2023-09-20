// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class MediaStreamModel
{
    [JsonPropertyName("direction")]
    public MediaStreamDirectionConstant? Direction { get; set; }

    [JsonPropertyName("label")]
    public string? Label { get; set; }

    [JsonPropertyName("mediaType")]
    public MediaStreamMediaTypeConstant? MediaType { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("serverMuted")]
    public bool? ServerMuted { get; set; }

    [JsonPropertyName("sourceId")]
    public string? SourceId { get; set; }
}
