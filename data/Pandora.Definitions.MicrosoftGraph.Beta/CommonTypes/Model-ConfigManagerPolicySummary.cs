// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ConfigManagerPolicySummaryModel
{
    [JsonPropertyName("compliantDeviceCount")]
    public int? CompliantDeviceCount { get; set; }

    [JsonPropertyName("enforcedDeviceCount")]
    public int? EnforcedDeviceCount { get; set; }

    [JsonPropertyName("failedDeviceCount")]
    public int? FailedDeviceCount { get; set; }

    [JsonPropertyName("nonCompliantDeviceCount")]
    public int? NonCompliantDeviceCount { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("pendingDeviceCount")]
    public int? PendingDeviceCount { get; set; }

    [JsonPropertyName("targetedDeviceCount")]
    public int? TargetedDeviceCount { get; set; }
}
