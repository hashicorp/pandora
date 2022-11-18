using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.VMware.v2022_05_01.Scripts;


internal class ScriptExecutionPropertiesModel
{
    [JsonPropertyName("errors")]
    public List<string>? Errors { get; set; }

    [JsonPropertyName("failureReason")]
    public string? FailureReason { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("finishedAt")]
    public DateTime? FinishedAt { get; set; }

    [JsonPropertyName("hiddenParameters")]
    public List<ScriptExecutionParameterModel>? HiddenParameters { get; set; }

    [JsonPropertyName("information")]
    public List<string>? Information { get; set; }

    [JsonPropertyName("namedOutputs")]
    public Dictionary<string, object>? NamedOutputs { get; set; }

    [JsonPropertyName("output")]
    public List<string>? Output { get; set; }

    [JsonPropertyName("parameters")]
    public List<ScriptExecutionParameterModel>? Parameters { get; set; }

    [JsonPropertyName("provisioningState")]
    public ScriptExecutionProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("retention")]
    public string? Retention { get; set; }

    [JsonPropertyName("scriptCmdletId")]
    public string? ScriptCmdletId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startedAt")]
    public DateTime? StartedAt { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("submittedAt")]
    public DateTime? SubmittedAt { get; set; }

    [JsonPropertyName("timeout")]
    [Required]
    public string Timeout { get; set; }

    [JsonPropertyName("warnings")]
    public List<string>? Warnings { get; set; }
}
