// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class PropertyModel
{
    [JsonPropertyName("aliases")]
    public List<string>? Aliases { get; set; }

    [JsonPropertyName("isExactMatchRequired")]
    public bool? IsExactMatchRequired { get; set; }

    [JsonPropertyName("isQueryable")]
    public bool? IsQueryable { get; set; }

    [JsonPropertyName("isRefinable")]
    public bool? IsRefinable { get; set; }

    [JsonPropertyName("isRetrievable")]
    public bool? IsRetrievable { get; set; }

    [JsonPropertyName("isSearchable")]
    public bool? IsSearchable { get; set; }

    [JsonPropertyName("labels")]
    public List<LabelConstant>? Labels { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("rankingHint")]
    public RankingHintModel? RankingHint { get; set; }

    [JsonPropertyName("type")]
    public PropertyTypeConstant? Type { get; set; }
}
