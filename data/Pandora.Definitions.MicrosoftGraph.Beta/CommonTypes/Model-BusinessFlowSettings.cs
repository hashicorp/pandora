// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class BusinessFlowSettingsModel
{
    [JsonPropertyName("accessRecommendationsEnabled")]
    public bool? AccessRecommendationsEnabled { get; set; }

    [JsonPropertyName("activityDurationInDays")]
    public int? ActivityDurationInDays { get; set; }

    [JsonPropertyName("autoApplyReviewResultsEnabled")]
    public bool? AutoApplyReviewResultsEnabled { get; set; }

    [JsonPropertyName("autoReviewEnabled")]
    public bool? AutoReviewEnabled { get; set; }

    [JsonPropertyName("autoReviewSettings")]
    public AutoReviewSettingsModel? AutoReviewSettings { get; set; }

    [JsonPropertyName("durationInDays")]
    public int? DurationInDays { get; set; }

    [JsonPropertyName("justificationRequiredOnApproval")]
    public bool? JustificationRequiredOnApproval { get; set; }

    [JsonPropertyName("mailNotificationsEnabled")]
    public bool? MailNotificationsEnabled { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("recurrenceSettings")]
    public AccessReviewRecurrenceSettingsModel? RecurrenceSettings { get; set; }

    [JsonPropertyName("remindersEnabled")]
    public bool? RemindersEnabled { get; set; }
}
