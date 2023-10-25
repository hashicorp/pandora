using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.JobTargetExecutions;


internal class JobExecutionPropertiesModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createTime")]
    public DateTime? CreateTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("currentAttemptStartTime")]
    public DateTime? CurrentAttemptStartTime { get; set; }

    [JsonPropertyName("currentAttempts")]
    public int? CurrentAttempts { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("endTime")]
    public DateTime? EndTime { get; set; }

    [JsonPropertyName("jobExecutionId")]
    public string? JobExecutionId { get; set; }

    [JsonPropertyName("jobVersion")]
    public int? JobVersion { get; set; }

    [JsonPropertyName("lastMessage")]
    public string? LastMessage { get; set; }

    [JsonPropertyName("lifecycle")]
    public JobExecutionLifecycleConstant? Lifecycle { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startTime")]
    public DateTime? StartTime { get; set; }

    [JsonPropertyName("stepId")]
    public int? StepId { get; set; }

    [JsonPropertyName("stepName")]
    public string? StepName { get; set; }

    [JsonPropertyName("target")]
    public JobExecutionTargetModel? Target { get; set; }
}
