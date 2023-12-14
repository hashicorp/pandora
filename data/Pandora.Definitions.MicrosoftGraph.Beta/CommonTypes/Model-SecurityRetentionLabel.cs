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
    public SecurityRetentionLabelActionAfterRetentionPeriodConstant? ActionAfterRetentionPeriod { get; set; }

    [JsonPropertyName("behaviorDuringRetentionPeriod")]
    public SecurityRetentionLabelBehaviorDuringRetentionPeriodConstant? BehaviorDuringRetentionPeriod { get; set; }

    [JsonPropertyName("createdBy")]
    public IdentitySetModel? CreatedBy { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("defaultRecordBehavior")]
    public SecurityRetentionLabelDefaultRecordBehaviorConstant? DefaultRecordBehavior { get; set; }

    [JsonPropertyName("descriptionForAdmins")]
    public string? DescriptionForAdmins { get; set; }

    [JsonPropertyName("descriptionForUsers")]
    public string? DescriptionForUsers { get; set; }

    [JsonPropertyName("descriptors")]
    public SecurityFilePlanDescriptorModel? Descriptors { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("dispositionReviewStages")]
    public List<SecurityDispositionReviewStageModel>? DispositionReviewStages { get; set; }

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
    public SecurityRetentionDurationModel? RetentionDuration { get; set; }

    [JsonPropertyName("retentionEventType")]
    public SecurityRetentionEventTypeModel? RetentionEventType { get; set; }

    [JsonPropertyName("retentionTrigger")]
    public SecurityRetentionLabelRetentionTriggerConstant? RetentionTrigger { get; set; }
}
