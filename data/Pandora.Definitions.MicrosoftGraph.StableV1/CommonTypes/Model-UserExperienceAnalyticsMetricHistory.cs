// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class UserExperienceAnalyticsMetricHistoryModel
{
    [JsonPropertyName("deviceId")]
    public string? DeviceId { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("metricDateTime")]
    public DateTime? MetricDateTime { get; set; }

    [JsonPropertyName("metricType")]
    public string? MetricType { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
