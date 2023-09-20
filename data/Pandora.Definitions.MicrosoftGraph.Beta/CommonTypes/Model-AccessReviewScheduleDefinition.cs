// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AccessReviewScheduleDefinitionModel
{
    [JsonPropertyName("additionalNotificationRecipients")]
    public List<AccessReviewNotificationRecipientItemModel>? AdditionalNotificationRecipients { get; set; }

    [JsonPropertyName("backupReviewers")]
    public List<AccessReviewReviewerScopeModel>? BackupReviewers { get; set; }

    [JsonPropertyName("createdBy")]
    public UserIdentityModel? CreatedBy { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("descriptionForAdmins")]
    public string? DescriptionForAdmins { get; set; }

    [JsonPropertyName("descriptionForReviewers")]
    public string? DescriptionForReviewers { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("fallbackReviewers")]
    public List<AccessReviewReviewerScopeModel>? FallbackReviewers { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("instanceEnumerationScope")]
    public AccessReviewScopeModel? InstanceEnumerationScope { get; set; }

    [JsonPropertyName("instances")]
    public List<AccessReviewInstanceModel>? Instances { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("reviewers")]
    public List<AccessReviewReviewerScopeModel>? Reviewers { get; set; }

    [JsonPropertyName("scope")]
    public AccessReviewScopeModel? Scope { get; set; }

    [JsonPropertyName("settings")]
    public AccessReviewScheduleSettingsModel? Settings { get; set; }

    [JsonPropertyName("stageSettings")]
    public List<AccessReviewStageSettingsModel>? StageSettings { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
