// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class AccessReviewHistoryDefinitionModel
{
    [JsonPropertyName("createdBy")]
    public UserIdentityModel? CreatedBy { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("decisions")]
    public List<AccessReviewHistoryDefinitionDecisionsConstant>? Decisions { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("instances")]
    public List<AccessReviewHistoryInstanceModel>? Instances { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("reviewHistoryPeriodEndDateTime")]
    public DateTime? ReviewHistoryPeriodEndDateTime { get; set; }

    [JsonPropertyName("reviewHistoryPeriodStartDateTime")]
    public DateTime? ReviewHistoryPeriodStartDateTime { get; set; }

    [JsonPropertyName("scheduleSettings")]
    public AccessReviewHistoryScheduleSettingsModel? ScheduleSettings { get; set; }

    [JsonPropertyName("scopes")]
    public List<AccessReviewScopeModel>? Scopes { get; set; }

    [JsonPropertyName("status")]
    public AccessReviewHistoryDefinitionStatusConstant? Status { get; set; }
}
