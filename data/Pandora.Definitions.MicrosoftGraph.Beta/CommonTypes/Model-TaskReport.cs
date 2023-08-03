// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class TaskReportModel
{
    [JsonPropertyName("completedDateTime")]
    public DateTime? CompletedDateTime { get; set; }

    [JsonPropertyName("failedUsersCount")]
    public int? FailedUsersCount { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastUpdatedDateTime")]
    public DateTime? LastUpdatedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("processingStatus")]
    public LifecycleWorkflowProcessingStatusConstant? ProcessingStatus { get; set; }

    [JsonPropertyName("runId")]
    public string? RunId { get; set; }

    [JsonPropertyName("startedDateTime")]
    public DateTime? StartedDateTime { get; set; }

    [JsonPropertyName("successfulUsersCount")]
    public int? SuccessfulUsersCount { get; set; }

    [JsonPropertyName("task")]
    public TaskModel? Task { get; set; }

    [JsonPropertyName("taskDefinition")]
    public TaskDefinitionModel? TaskDefinition { get; set; }

    [JsonPropertyName("taskProcessingResults")]
    public List<TaskProcessingResultModel>? TaskProcessingResults { get; set; }

    [JsonPropertyName("totalUsersCount")]
    public int? TotalUsersCount { get; set; }

    [JsonPropertyName("unprocessedUsersCount")]
    public int? UnprocessedUsersCount { get; set; }
}
