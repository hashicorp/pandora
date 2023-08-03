// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AccessReviewStageSettingsModel
{
    [JsonPropertyName("decisionsThatWillMoveToNextStage")]
    public List<string>? DecisionsThatWillMoveToNextStage { get; set; }

    [JsonPropertyName("dependsOn")]
    public List<string>? DependsOn { get; set; }

    [JsonPropertyName("durationInDays")]
    public int? DurationInDays { get; set; }

    [JsonPropertyName("fallbackReviewers")]
    public List<AccessReviewReviewerScopeModel>? FallbackReviewers { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("recommendationInsightSettings")]
    public List<AccessReviewRecommendationInsightSettingModel>? RecommendationInsightSettings { get; set; }

    [JsonPropertyName("recommendationLookBackDuration")]
    public string? RecommendationLookBackDuration { get; set; }

    [JsonPropertyName("recommendationsEnabled")]
    public bool? RecommendationsEnabled { get; set; }

    [JsonPropertyName("reviewers")]
    public List<AccessReviewReviewerScopeModel>? Reviewers { get; set; }

    [JsonPropertyName("stageId")]
    public string? StageId { get; set; }
}
