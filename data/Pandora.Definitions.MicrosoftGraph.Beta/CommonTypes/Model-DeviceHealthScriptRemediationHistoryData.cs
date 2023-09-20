// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceHealthScriptRemediationHistoryDataModel
{
    [JsonPropertyName("date")]
    public DateTime? Date { get; set; }

    [JsonPropertyName("detectFailedDeviceCount")]
    public int? DetectFailedDeviceCount { get; set; }

    [JsonPropertyName("noIssueDeviceCount")]
    public int? NoIssueDeviceCount { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("remediatedDeviceCount")]
    public int? RemediatedDeviceCount { get; set; }
}
