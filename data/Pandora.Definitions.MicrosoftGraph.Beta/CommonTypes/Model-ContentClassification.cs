// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ContentClassificationModel
{
    [JsonPropertyName("confidence")]
    public int? Confidence { get; set; }

    [JsonPropertyName("matches")]
    public List<MatchLocationModel>? Matches { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("sensitiveTypeId")]
    public string? SensitiveTypeId { get; set; }

    [JsonPropertyName("uniqueCount")]
    public int? UniqueCount { get; set; }
}
