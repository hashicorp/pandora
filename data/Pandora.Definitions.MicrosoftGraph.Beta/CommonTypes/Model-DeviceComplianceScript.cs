// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceComplianceScriptModel
{
    [JsonPropertyName("assignments")]
    public List<DeviceHealthScriptAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("detectionScriptContent")]
    public string? DetectionScriptContent { get; set; }

    [JsonPropertyName("deviceRunStates")]
    public List<DeviceComplianceScriptDeviceStateModel>? DeviceRunStates { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("enforceSignatureCheck")]
    public bool? EnforceSignatureCheck { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("publisher")]
    public string? Publisher { get; set; }

    [JsonPropertyName("roleScopeTagIds")]
    public List<string>? RoleScopeTagIds { get; set; }

    [JsonPropertyName("runAs32Bit")]
    public bool? RunAs32Bit { get; set; }

    [JsonPropertyName("runAsAccount")]
    public RunAsAccountTypeConstant? RunAsAccount { get; set; }

    [JsonPropertyName("runSummary")]
    public DeviceComplianceScriptRunSummaryModel? RunSummary { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
