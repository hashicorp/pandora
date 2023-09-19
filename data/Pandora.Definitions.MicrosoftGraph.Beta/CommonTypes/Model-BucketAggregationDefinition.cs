// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class BucketAggregationDefinitionModel
{
    [JsonPropertyName("isDescending")]
    public bool? IsDescending { get; set; }

    [JsonPropertyName("minimumCount")]
    public int? MinimumCount { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("prefixFilter")]
    public string? PrefixFilter { get; set; }

    [JsonPropertyName("ranges")]
    public List<BucketAggregationRangeModel>? Ranges { get; set; }

    [JsonPropertyName("sortBy")]
    public BucketAggregationDefinitionSortByConstant? SortBy { get; set; }
}
