// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class OfficeGraphInsightsModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("shared")]
    public List<SharedInsightModel>? Shared { get; set; }

    [JsonPropertyName("trending")]
    public List<TrendingModel>? Trending { get; set; }

    [JsonPropertyName("used")]
    public List<UsedInsightModel>? Used { get; set; }
}
