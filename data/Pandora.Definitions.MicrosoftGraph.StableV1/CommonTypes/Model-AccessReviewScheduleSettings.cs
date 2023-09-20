// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class AccessReviewScheduleSettingsModel
{
    [JsonPropertyName("applyActions")]
    public List<AccessReviewApplyActionModel>? ApplyActions { get; set; }

    [JsonPropertyName("autoApplyDecisionsEnabled")]
    public bool? AutoApplyDecisionsEnabled { get; set; }

    [JsonPropertyName("decisionHistoriesForReviewersEnabled")]
    public bool? DecisionHistoriesForReviewersEnabled { get; set; }

    [JsonPropertyName("defaultDecision")]
    public string? DefaultDecision { get; set; }

    [JsonPropertyName("defaultDecisionEnabled")]
    public bool? DefaultDecisionEnabled { get; set; }

    [JsonPropertyName("instanceDurationInDays")]
    public int? InstanceDurationInDays { get; set; }

    [JsonPropertyName("justificationRequiredOnApproval")]
    public bool? JustificationRequiredOnApproval { get; set; }

    [JsonPropertyName("mailNotificationsEnabled")]
    public bool? MailNotificationsEnabled { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("recommendationInsightSettings")]
    public List<AccessReviewRecommendationInsightSettingModel>? RecommendationInsightSettings { get; set; }

    [JsonPropertyName("recommendationLookBackDuration")]
    public string? RecommendationLookBackDuration { get; set; }

    [JsonPropertyName("recommendationsEnabled")]
    public bool? RecommendationsEnabled { get; set; }

    [JsonPropertyName("recurrence")]
    public PatternedRecurrenceModel? Recurrence { get; set; }

    [JsonPropertyName("reminderNotificationsEnabled")]
    public bool? ReminderNotificationsEnabled { get; set; }
}
