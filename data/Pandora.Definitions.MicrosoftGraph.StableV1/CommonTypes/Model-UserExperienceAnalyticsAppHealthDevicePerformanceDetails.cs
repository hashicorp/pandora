// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class UserExperienceAnalyticsAppHealthDevicePerformanceDetailsModel
{
    [JsonPropertyName("appDisplayName")]
    public string? AppDisplayName { get; set; }

    [JsonPropertyName("appPublisher")]
    public string? AppPublisher { get; set; }

    [JsonPropertyName("appVersion")]
    public string? AppVersion { get; set; }

    [JsonPropertyName("deviceDisplayName")]
    public string? DeviceDisplayName { get; set; }

    [JsonPropertyName("deviceId")]
    public string? DeviceId { get; set; }

    [JsonPropertyName("eventDateTime")]
    public DateTime? EventDateTime { get; set; }

    [JsonPropertyName("eventType")]
    public string? EventType { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
