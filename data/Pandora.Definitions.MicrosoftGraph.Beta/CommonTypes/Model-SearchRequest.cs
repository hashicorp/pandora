// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SearchRequestModel
{
    [JsonPropertyName("aggregationFilters")]
    public List<string>? AggregationFilters { get; set; }

    [JsonPropertyName("aggregations")]
    public List<AggregationOptionModel>? Aggregations { get; set; }

    [JsonPropertyName("collapseProperties")]
    public List<CollapsePropertyModel>? CollapseProperties { get; set; }

    [JsonPropertyName("contentSources")]
    public List<string>? ContentSources { get; set; }

    [JsonPropertyName("enableTopResults")]
    public bool? EnableTopResults { get; set; }

    [JsonPropertyName("entityTypes")]
    public List<EntityTypeConstant>? EntityTypes { get; set; }

    [JsonPropertyName("fields")]
    public List<string>? Fields { get; set; }

    [JsonPropertyName("from")]
    public int? From { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("query")]
    public SearchQueryModel? Query { get; set; }

    [JsonPropertyName("queryAlterationOptions")]
    public SearchAlterationOptionsModel? QueryAlterationOptions { get; set; }

    [JsonPropertyName("region")]
    public string? Region { get; set; }

    [JsonPropertyName("resultTemplateOptions")]
    public ResultTemplateOptionModel? ResultTemplateOptions { get; set; }

    [JsonPropertyName("sharePointOneDriveOptions")]
    public SharePointOneDriveOptionsModel? SharePointOneDriveOptions { get; set; }

    [JsonPropertyName("size")]
    public int? Size { get; set; }

    [JsonPropertyName("sortProperties")]
    public List<SortPropertyModel>? SortProperties { get; set; }

    [JsonPropertyName("stored_fields")]
    public List<string>? Storedfields { get; set; }

    [JsonPropertyName("trimDuplicates")]
    public bool? TrimDuplicates { get; set; }
}
