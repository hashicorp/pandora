// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class AccessPackageAssignmentReviewSettingsModel
{
    [JsonPropertyName("expirationBehavior")]
    public AccessPackageAssignmentReviewSettingsExpirationBehaviorConstant? ExpirationBehavior { get; set; }

    [JsonPropertyName("fallbackReviewers")]
    public List<SubjectSetModel>? FallbackReviewers { get; set; }

    [JsonPropertyName("isEnabled")]
    public bool? IsEnabled { get; set; }

    [JsonPropertyName("isRecommendationEnabled")]
    public bool? IsRecommendationEnabled { get; set; }

    [JsonPropertyName("isReviewerJustificationRequired")]
    public bool? IsReviewerJustificationRequired { get; set; }

    [JsonPropertyName("isSelfReview")]
    public bool? IsSelfReview { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("primaryReviewers")]
    public List<SubjectSetModel>? PrimaryReviewers { get; set; }

    [JsonPropertyName("schedule")]
    public EntitlementManagementScheduleModel? Schedule { get; set; }
}
