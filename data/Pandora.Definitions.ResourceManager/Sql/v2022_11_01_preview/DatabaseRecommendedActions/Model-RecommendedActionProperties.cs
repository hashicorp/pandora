using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.DatabaseRecommendedActions;


internal class RecommendedActionPropertiesModel
{
    [JsonPropertyName("details")]
    public Dictionary<string, object>? Details { get; set; }

    [JsonPropertyName("errorDetails")]
    public RecommendedActionErrorInfoModel? ErrorDetails { get; set; }

    [JsonPropertyName("estimatedImpact")]
    public List<RecommendedActionImpactRecordModel>? EstimatedImpact { get; set; }

    [JsonPropertyName("executeActionDuration")]
    public string? ExecuteActionDuration { get; set; }

    [JsonPropertyName("executeActionInitiatedBy")]
    public RecommendedActionInitiatedByConstant? ExecuteActionInitiatedBy { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("executeActionInitiatedTime")]
    public DateTime? ExecuteActionInitiatedTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("executeActionStartTime")]
    public DateTime? ExecuteActionStartTime { get; set; }

    [JsonPropertyName("implementationDetails")]
    public RecommendedActionImplementationInfoModel? ImplementationDetails { get; set; }

    [JsonPropertyName("isArchivedAction")]
    public bool? IsArchivedAction { get; set; }

    [JsonPropertyName("isExecutableAction")]
    public bool? IsExecutableAction { get; set; }

    [JsonPropertyName("isRevertableAction")]
    public bool? IsRevertableAction { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastRefresh")]
    public DateTime? LastRefresh { get; set; }

    [JsonPropertyName("linkedObjects")]
    public List<string>? LinkedObjects { get; set; }

    [JsonPropertyName("observedImpact")]
    public List<RecommendedActionImpactRecordModel>? ObservedImpact { get; set; }

    [JsonPropertyName("recommendationReason")]
    public string? RecommendationReason { get; set; }

    [JsonPropertyName("revertActionDuration")]
    public string? RevertActionDuration { get; set; }

    [JsonPropertyName("revertActionInitiatedBy")]
    public RecommendedActionInitiatedByConstant? RevertActionInitiatedBy { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("revertActionInitiatedTime")]
    public DateTime? RevertActionInitiatedTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("revertActionStartTime")]
    public DateTime? RevertActionStartTime { get; set; }

    [JsonPropertyName("score")]
    public int? Score { get; set; }

    [JsonPropertyName("state")]
    [Required]
    public RecommendedActionStateInfoModel State { get; set; }

    [JsonPropertyName("timeSeries")]
    public List<RecommendedActionMetricInfoModel>? TimeSeries { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("validSince")]
    public DateTime? ValidSince { get; set; }
}
