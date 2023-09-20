// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class RecommendationModel
{
    [JsonPropertyName("actionSteps")]
    public List<ActionStepModel>? ActionSteps { get; set; }

    [JsonPropertyName("benefits")]
    public string? Benefits { get; set; }

    [JsonPropertyName("category")]
    public RecommendationCategoryConstant? Category { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("featureAreas")]
    public List<RecommendationFeatureAreasConstant>? FeatureAreas { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("impactStartDateTime")]
    public DateTime? ImpactStartDateTime { get; set; }

    [JsonPropertyName("impactType")]
    public string? ImpactType { get; set; }

    [JsonPropertyName("impactedResources")]
    public List<ImpactedResourceModel>? ImpactedResources { get; set; }

    [JsonPropertyName("insights")]
    public string? Insights { get; set; }

    [JsonPropertyName("lastCheckedDateTime")]
    public DateTime? LastCheckedDateTime { get; set; }

    [JsonPropertyName("lastModifiedBy")]
    public string? LastModifiedBy { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("postponeUntilDateTime")]
    public DateTime? PostponeUntilDateTime { get; set; }

    [JsonPropertyName("priority")]
    public RecommendationPriorityConstant? Priority { get; set; }

    [JsonPropertyName("recommendationType")]
    public RecommendationRecommendationTypeConstant? RecommendationType { get; set; }

    [JsonPropertyName("releaseType")]
    public string? ReleaseType { get; set; }

    [JsonPropertyName("remediationImpact")]
    public string? RemediationImpact { get; set; }

    [JsonPropertyName("status")]
    public RecommendationStatusConstant? Status { get; set; }
}
