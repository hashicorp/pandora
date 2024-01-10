// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AssignmentReviewSettingsModel
{
    [JsonPropertyName("accessReviewTimeoutBehavior")]
    public AssignmentReviewSettingsAccessReviewTimeoutBehaviorConstant? AccessReviewTimeoutBehavior { get; set; }

    [JsonPropertyName("durationInDays")]
    public int? DurationInDays { get; set; }

    [JsonPropertyName("isAccessRecommendationEnabled")]
    public bool? IsAccessRecommendationEnabled { get; set; }

    [JsonPropertyName("isApprovalJustificationRequired")]
    public bool? IsApprovalJustificationRequired { get; set; }

    [JsonPropertyName("isEnabled")]
    public bool? IsEnabled { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("recurrenceType")]
    public string? RecurrenceType { get; set; }

    [JsonPropertyName("reviewerType")]
    public string? ReviewerType { get; set; }

    [JsonPropertyName("reviewers")]
    public List<UserSetModel>? Reviewers { get; set; }

    [JsonPropertyName("startDateTime")]
    public DateTime? StartDateTime { get; set; }
}
