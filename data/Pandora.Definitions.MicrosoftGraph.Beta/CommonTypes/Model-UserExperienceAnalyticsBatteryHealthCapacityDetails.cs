// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class UserExperienceAnalyticsBatteryHealthCapacityDetailsModel
{
    [JsonPropertyName("activeDevices")]
    public int? ActiveDevices { get; set; }

    [JsonPropertyName("batteryCapacityFair")]
    public int? BatteryCapacityFair { get; set; }

    [JsonPropertyName("batteryCapacityGood")]
    public int? BatteryCapacityGood { get; set; }

    [JsonPropertyName("batteryCapacityPoor")]
    public int? BatteryCapacityPoor { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastRefreshedDateTime")]
    public DateTime? LastRefreshedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
