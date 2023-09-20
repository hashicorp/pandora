// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class UserExperienceAnalyticsBatteryHealthAppImpactModel
{
    [JsonPropertyName("activeDevices")]
    public int? ActiveDevices { get; set; }

    [JsonPropertyName("appDisplayName")]
    public string? AppDisplayName { get; set; }

    [JsonPropertyName("appName")]
    public string? AppName { get; set; }

    [JsonPropertyName("appPublisher")]
    public string? AppPublisher { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isForegroundApp")]
    public bool? IsForegroundApp { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
