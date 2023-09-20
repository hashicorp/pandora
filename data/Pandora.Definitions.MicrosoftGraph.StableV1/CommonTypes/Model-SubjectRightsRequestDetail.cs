// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class SubjectRightsRequestDetailModel
{
    [JsonPropertyName("excludedItemCount")]
    public int? ExcludedItemCount { get; set; }

    [JsonPropertyName("insightCounts")]
    public List<KeyValuePairModel>? InsightCounts { get; set; }

    [JsonPropertyName("itemCount")]
    public int? ItemCount { get; set; }

    [JsonPropertyName("itemNeedReview")]
    public int? ItemNeedReview { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("productItemCounts")]
    public List<KeyValuePairModel>? ProductItemCounts { get; set; }

    [JsonPropertyName("signedOffItemCount")]
    public int? SignedOffItemCount { get; set; }

    [JsonPropertyName("totalItemSize")]
    public int? TotalItemSize { get; set; }
}
