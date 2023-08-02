// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WorkflowModel
{
    [JsonPropertyName("category")]
    public LifecycleWorkflowCategoryConstant? Category { get; set; }

    [JsonPropertyName("createdBy")]
    public UserModel? CreatedBy { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("deletedDateTime")]
    public DateTime? DeletedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("executionConditions")]
    public WorkflowExecutionConditionsModel? ExecutionConditions { get; set; }

    [JsonPropertyName("executionScope")]
    public List<UserProcessingResultModel>? ExecutionScope { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isEnabled")]
    public bool? IsEnabled { get; set; }

    [JsonPropertyName("isSchedulingEnabled")]
    public bool? IsSchedulingEnabled { get; set; }

    [JsonPropertyName("lastModifiedBy")]
    public UserModel? LastModifiedBy { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("nextScheduleRunDateTime")]
    public DateTime? NextScheduleRunDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("runs")]
    public List<RunModel>? Runs { get; set; }

    [JsonPropertyName("taskReports")]
    public List<TaskReportModel>? TaskReports { get; set; }

    [JsonPropertyName("tasks")]
    public List<TaskModel>? Tasks { get; set; }

    [JsonPropertyName("userProcessingResults")]
    public List<UserProcessingResultModel>? UserProcessingResults { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }

    [JsonPropertyName("versions")]
    public List<WorkflowVersionModel>? Versions { get; set; }
}
