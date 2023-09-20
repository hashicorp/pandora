// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class EBookInstallSummaryModel
{
    [JsonPropertyName("failedDeviceCount")]
    public int? FailedDeviceCount { get; set; }

    [JsonPropertyName("failedUserCount")]
    public int? FailedUserCount { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("installedDeviceCount")]
    public int? InstalledDeviceCount { get; set; }

    [JsonPropertyName("installedUserCount")]
    public int? InstalledUserCount { get; set; }

    [JsonPropertyName("notInstalledDeviceCount")]
    public int? NotInstalledDeviceCount { get; set; }

    [JsonPropertyName("notInstalledUserCount")]
    public int? NotInstalledUserCount { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
