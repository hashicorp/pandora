using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.WorkflowRuns;


internal class WorkflowRunPropertiesModel
{
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    [JsonPropertyName("correlation")]
    public CorrelationModel? Correlation { get; set; }

    [JsonPropertyName("correlationId")]
    public string? CorrelationId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("endTime")]
    public DateTime? EndTime { get; set; }

    [JsonPropertyName("error")]
    public object? Error { get; set; }

    [JsonPropertyName("outputs")]
    public Dictionary<string, WorkflowOutputParameterModel>? Outputs { get; set; }

    [JsonPropertyName("response")]
    public WorkflowRunTriggerModel? Response { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startTime")]
    public DateTime? StartTime { get; set; }

    [JsonPropertyName("status")]
    public WorkflowStatusConstant? Status { get; set; }

    [JsonPropertyName("trigger")]
    public WorkflowRunTriggerModel? Trigger { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("waitEndTime")]
    public DateTime? WaitEndTime { get; set; }

    [JsonPropertyName("workflow")]
    public ResourceReferenceModel? Workflow { get; set; }
}
