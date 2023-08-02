// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceCompliancePolicySettingStateSummaryModel
{
    [JsonPropertyName("compliantDeviceCount")]
    public int? CompliantDeviceCount { get; set; }

    [JsonPropertyName("conflictDeviceCount")]
    public int? ConflictDeviceCount { get; set; }

    [JsonPropertyName("deviceComplianceSettingStates")]
    public List<DeviceComplianceSettingStateModel>? DeviceComplianceSettingStates { get; set; }

    [JsonPropertyName("errorDeviceCount")]
    public int? ErrorDeviceCount { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("nonCompliantDeviceCount")]
    public int? NonCompliantDeviceCount { get; set; }

    [JsonPropertyName("notApplicableDeviceCount")]
    public int? NotApplicableDeviceCount { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("platformType")]
    public PolicyPlatformTypeConstant? PlatformType { get; set; }

    [JsonPropertyName("remediatedDeviceCount")]
    public int? RemediatedDeviceCount { get; set; }

    [JsonPropertyName("setting")]
    public string? Setting { get; set; }

    [JsonPropertyName("settingName")]
    public string? SettingName { get; set; }

    [JsonPropertyName("unknownDeviceCount")]
    public int? UnknownDeviceCount { get; set; }
}
