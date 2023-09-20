// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceShellScriptModel
{
    [JsonPropertyName("assignments")]
    public List<DeviceManagementScriptAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("blockExecutionNotifications")]
    public bool? BlockExecutionNotifications { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("deviceRunStates")]
    public List<DeviceManagementScriptDeviceStateModel>? DeviceRunStates { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("executionFrequency")]
    public string? ExecutionFrequency { get; set; }

    [JsonPropertyName("fileName")]
    public string? FileName { get; set; }

    [JsonPropertyName("groupAssignments")]
    public List<DeviceManagementScriptGroupAssignmentModel>? GroupAssignments { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("retryCount")]
    public int? RetryCount { get; set; }

    [JsonPropertyName("roleScopeTagIds")]
    public List<string>? RoleScopeTagIds { get; set; }

    [JsonPropertyName("runAsAccount")]
    public DeviceShellScriptRunAsAccountConstant? RunAsAccount { get; set; }

    [JsonPropertyName("runSummary")]
    public DeviceManagementScriptRunSummaryModel? RunSummary { get; set; }

    [JsonPropertyName("scriptContent")]
    public string? ScriptContent { get; set; }

    [JsonPropertyName("userRunStates")]
    public List<DeviceManagementScriptUserStateModel>? UserRunStates { get; set; }
}
