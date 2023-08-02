// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SecurityRetentionLabelModel
{
    [JsonPropertyName("actionAfterRetentionPeriod")]
    public ActionAfterRetentionPeriodConstant? ActionAfterRetentionPeriod { get; set; }

    [JsonPropertyName("behaviorDuringRetentionPeriod")]
    public BehaviorDuringRetentionPeriodConstant? BehaviorDuringRetentionPeriod { get; set; }

    [JsonPropertyName("createdBy")]
    public IdentitySetModel? CreatedBy { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("defaultRecordBehavior")]
    public DefaultRecordBehaviorConstant? DefaultRecordBehavior { get; set; }

    [JsonPropertyName("descriptionForAdmins")]
    public string? DescriptionForAdmins { get; set; }

    [JsonPropertyName("descriptionForUsers")]
    public string? DescriptionForUsers { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("dispositionReviewStages")]
    public List<DispositionReviewStageModel>? DispositionReviewStages { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isInUse")]
    public bool? IsInUse { get; set; }

    [JsonPropertyName("labelToBeApplied")]
    public string? LabelToBeApplied { get; set; }

    [JsonPropertyName("lastModifiedBy")]
    public IdentitySetModel? LastModifiedBy { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("retentionDuration")]
    public RetentionDurationModel? RetentionDuration { get; set; }

    [JsonPropertyName("retentionEventType")]
    public RetentionEventTypeModel? RetentionEventType { get; set; }

    [JsonPropertyName("retentionTrigger")]
    public RetentionTriggerConstant? RetentionTrigger { get; set; }
}
