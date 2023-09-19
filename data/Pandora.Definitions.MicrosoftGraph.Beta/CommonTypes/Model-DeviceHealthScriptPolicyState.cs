// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceHealthScriptPolicyStateModel
{
    [JsonPropertyName("assignmentFilterIds")]
    public List<string>? AssignmentFilterIds { get; set; }

    [JsonPropertyName("detectionState")]
    public DeviceHealthScriptPolicyStateDetectionStateConstant? DetectionState { get; set; }

    [JsonPropertyName("deviceId")]
    public string? DeviceId { get; set; }

    [JsonPropertyName("deviceName")]
    public string? DeviceName { get; set; }

    [JsonPropertyName("expectedStateUpdateDateTime")]
    public DateTime? ExpectedStateUpdateDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastStateUpdateDateTime")]
    public DateTime? LastStateUpdateDateTime { get; set; }

    [JsonPropertyName("lastSyncDateTime")]
    public DateTime? LastSyncDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("osVersion")]
    public string? OsVersion { get; set; }

    [JsonPropertyName("policyId")]
    public string? PolicyId { get; set; }

    [JsonPropertyName("policyName")]
    public string? PolicyName { get; set; }

    [JsonPropertyName("postRemediationDetectionScriptError")]
    public string? PostRemediationDetectionScriptError { get; set; }

    [JsonPropertyName("postRemediationDetectionScriptOutput")]
    public string? PostRemediationDetectionScriptOutput { get; set; }

    [JsonPropertyName("preRemediationDetectionScriptError")]
    public string? PreRemediationDetectionScriptError { get; set; }

    [JsonPropertyName("preRemediationDetectionScriptOutput")]
    public string? PreRemediationDetectionScriptOutput { get; set; }

    [JsonPropertyName("remediationScriptError")]
    public string? RemediationScriptError { get; set; }

    [JsonPropertyName("remediationState")]
    public DeviceHealthScriptPolicyStateRemediationStateConstant? RemediationState { get; set; }

    [JsonPropertyName("userName")]
    public string? UserName { get; set; }
}
