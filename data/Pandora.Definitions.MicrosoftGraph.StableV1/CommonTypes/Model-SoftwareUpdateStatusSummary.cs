// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class SoftwareUpdateStatusSummaryModel
{
    [JsonPropertyName("compliantDeviceCount")]
    public int? CompliantDeviceCount { get; set; }

    [JsonPropertyName("compliantUserCount")]
    public int? CompliantUserCount { get; set; }

    [JsonPropertyName("conflictDeviceCount")]
    public int? ConflictDeviceCount { get; set; }

    [JsonPropertyName("conflictUserCount")]
    public int? ConflictUserCount { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("errorDeviceCount")]
    public int? ErrorDeviceCount { get; set; }

    [JsonPropertyName("errorUserCount")]
    public int? ErrorUserCount { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("nonCompliantDeviceCount")]
    public int? NonCompliantDeviceCount { get; set; }

    [JsonPropertyName("nonCompliantUserCount")]
    public int? NonCompliantUserCount { get; set; }

    [JsonPropertyName("notApplicableDeviceCount")]
    public int? NotApplicableDeviceCount { get; set; }

    [JsonPropertyName("notApplicableUserCount")]
    public int? NotApplicableUserCount { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("remediatedDeviceCount")]
    public int? RemediatedDeviceCount { get; set; }

    [JsonPropertyName("remediatedUserCount")]
    public int? RemediatedUserCount { get; set; }

    [JsonPropertyName("unknownDeviceCount")]
    public int? UnknownDeviceCount { get; set; }

    [JsonPropertyName("unknownUserCount")]
    public int? UnknownUserCount { get; set; }
}
