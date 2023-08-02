// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AdvancedThreatProtectionOnboardingStateSummaryModel
{
    [JsonPropertyName("advancedThreatProtectionOnboardingDeviceSettingStates")]
    public List<AdvancedThreatProtectionOnboardingDeviceSettingStateModel>? AdvancedThreatProtectionOnboardingDeviceSettingStates { get; set; }

    [JsonPropertyName("compliantDeviceCount")]
    public int? CompliantDeviceCount { get; set; }

    [JsonPropertyName("conflictDeviceCount")]
    public int? ConflictDeviceCount { get; set; }

    [JsonPropertyName("errorDeviceCount")]
    public int? ErrorDeviceCount { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("nonCompliantDeviceCount")]
    public int? NonCompliantDeviceCount { get; set; }

    [JsonPropertyName("notApplicableDeviceCount")]
    public int? NotApplicableDeviceCount { get; set; }

    [JsonPropertyName("notAssignedDeviceCount")]
    public int? NotAssignedDeviceCount { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("remediatedDeviceCount")]
    public int? RemediatedDeviceCount { get; set; }

    [JsonPropertyName("unknownDeviceCount")]
    public int? UnknownDeviceCount { get; set; }
}
