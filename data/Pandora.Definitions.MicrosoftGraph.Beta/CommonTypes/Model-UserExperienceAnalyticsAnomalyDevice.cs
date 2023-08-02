// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class UserExperienceAnalyticsAnomalyDeviceModel
{
    [JsonPropertyName("anomalyId")]
    public string? AnomalyId { get; set; }

    [JsonPropertyName("anomalyOnDeviceFirstOccurrenceDateTime")]
    public DateTime? AnomalyOnDeviceFirstOccurrenceDateTime { get; set; }

    [JsonPropertyName("anomalyOnDeviceLatestOccurrenceDateTime")]
    public DateTime? AnomalyOnDeviceLatestOccurrenceDateTime { get; set; }

    [JsonPropertyName("deviceId")]
    public string? DeviceId { get; set; }

    [JsonPropertyName("deviceManufacturer")]
    public string? DeviceManufacturer { get; set; }

    [JsonPropertyName("deviceModel")]
    public string? DeviceModel { get; set; }

    [JsonPropertyName("deviceName")]
    public string? DeviceName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("osName")]
    public string? OsName { get; set; }

    [JsonPropertyName("osVersion")]
    public string? OsVersion { get; set; }
}
