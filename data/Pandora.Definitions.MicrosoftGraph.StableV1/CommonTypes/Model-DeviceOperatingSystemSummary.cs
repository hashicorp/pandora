// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class DeviceOperatingSystemSummaryModel
{
    [JsonPropertyName("androidCorporateWorkProfileCount")]
    public int? AndroidCorporateWorkProfileCount { get; set; }

    [JsonPropertyName("androidCount")]
    public int? AndroidCount { get; set; }

    [JsonPropertyName("androidDedicatedCount")]
    public int? AndroidDedicatedCount { get; set; }

    [JsonPropertyName("androidDeviceAdminCount")]
    public int? AndroidDeviceAdminCount { get; set; }

    [JsonPropertyName("androidFullyManagedCount")]
    public int? AndroidFullyManagedCount { get; set; }

    [JsonPropertyName("androidWorkProfileCount")]
    public int? AndroidWorkProfileCount { get; set; }

    [JsonPropertyName("configMgrDeviceCount")]
    public int? ConfigMgrDeviceCount { get; set; }

    [JsonPropertyName("iosCount")]
    public int? IosCount { get; set; }

    [JsonPropertyName("macOSCount")]
    public int? MacOSCount { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("unknownCount")]
    public int? UnknownCount { get; set; }

    [JsonPropertyName("windowsCount")]
    public int? WindowsCount { get; set; }

    [JsonPropertyName("windowsMobileCount")]
    public int? WindowsMobileCount { get; set; }
}
