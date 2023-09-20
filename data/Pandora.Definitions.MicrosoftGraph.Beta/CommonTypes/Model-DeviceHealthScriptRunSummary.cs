// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceHealthScriptRunSummaryModel
{
    [JsonPropertyName("detectionScriptErrorDeviceCount")]
    public int? DetectionScriptErrorDeviceCount { get; set; }

    [JsonPropertyName("detectionScriptNotApplicableDeviceCount")]
    public int? DetectionScriptNotApplicableDeviceCount { get; set; }

    [JsonPropertyName("detectionScriptPendingDeviceCount")]
    public int? DetectionScriptPendingDeviceCount { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("issueDetectedDeviceCount")]
    public int? IssueDetectedDeviceCount { get; set; }

    [JsonPropertyName("issueRemediatedCumulativeDeviceCount")]
    public int? IssueRemediatedCumulativeDeviceCount { get; set; }

    [JsonPropertyName("issueRemediatedDeviceCount")]
    public int? IssueRemediatedDeviceCount { get; set; }

    [JsonPropertyName("issueReoccurredDeviceCount")]
    public int? IssueReoccurredDeviceCount { get; set; }

    [JsonPropertyName("lastScriptRunDateTime")]
    public DateTime? LastScriptRunDateTime { get; set; }

    [JsonPropertyName("noIssueDetectedDeviceCount")]
    public int? NoIssueDetectedDeviceCount { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("remediationScriptErrorDeviceCount")]
    public int? RemediationScriptErrorDeviceCount { get; set; }

    [JsonPropertyName("remediationSkippedDeviceCount")]
    public int? RemediationSkippedDeviceCount { get; set; }
}
