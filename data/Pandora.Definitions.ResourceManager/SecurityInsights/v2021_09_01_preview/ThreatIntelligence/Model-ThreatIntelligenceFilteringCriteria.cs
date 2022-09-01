using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2021_09_01_preview.ThreatIntelligence;


internal class ThreatIntelligenceFilteringCriteriaModel
{
    [JsonPropertyName("ids")]
    public List<string>? Ids { get; set; }

    [JsonPropertyName("includeDisabled")]
    public bool? IncludeDisabled { get; set; }

    [JsonPropertyName("keywords")]
    public List<string>? Keywords { get; set; }

    [JsonPropertyName("maxConfidence")]
    public int? MaxConfidence { get; set; }

    [JsonPropertyName("maxValidUntil")]
    public string? MaxValidUntil { get; set; }

    [JsonPropertyName("minConfidence")]
    public int? MinConfidence { get; set; }

    [JsonPropertyName("minValidUntil")]
    public string? MinValidUntil { get; set; }

    [JsonPropertyName("pageSize")]
    public int? PageSize { get; set; }

    [JsonPropertyName("patternTypes")]
    public List<string>? PatternTypes { get; set; }

    [JsonPropertyName("skipToken")]
    public string? SkipToken { get; set; }

    [JsonPropertyName("sortBy")]
    public List<ThreatIntelligenceSortingCriteriaModel>? SortBy { get; set; }

    [JsonPropertyName("sources")]
    public List<string>? Sources { get; set; }

    [JsonPropertyName("threatTypes")]
    public List<string>? ThreatTypes { get; set; }
}
