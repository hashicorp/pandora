using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2020_08_01.Workspaces;


internal class SearchMetadataModel
{
    [JsonPropertyName("aggregatedGroupingFields")]
    public string? AggregatedGroupingFields { get; set; }

    [JsonPropertyName("aggregatedValueField")]
    public string? AggregatedValueField { get; set; }

    [JsonPropertyName("coreSummaries")]
    public List<CoreSummaryModel>? CoreSummaries { get; set; }

    [JsonPropertyName("eTag")]
    public string? ETag { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastUpdated")]
    public DateTime? LastUpdated { get; set; }

    [JsonPropertyName("max")]
    public int? Max { get; set; }

    [JsonPropertyName("requestId")]
    public string? RequestId { get; set; }

    [JsonPropertyName("requestTime")]
    public int? RequestTime { get; set; }

    [JsonPropertyName("resultType")]
    public string? ResultType { get; set; }

    [JsonPropertyName("schema")]
    public SearchMetadataSchemaModel? Schema { get; set; }

    [JsonPropertyName("sort")]
    public List<SearchSortModel>? Sort { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startTime")]
    public DateTime? StartTime { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("sum")]
    public int? Sum { get; set; }

    [JsonPropertyName("top")]
    public int? Top { get; set; }

    [JsonPropertyName("total")]
    public int? Total { get; set; }
}
