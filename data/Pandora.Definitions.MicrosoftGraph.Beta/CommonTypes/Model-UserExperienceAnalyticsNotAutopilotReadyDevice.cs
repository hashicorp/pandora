// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class UserExperienceAnalyticsNotAutopilotReadyDeviceModel
{
    [JsonPropertyName("autoPilotProfileAssigned")]
    public bool? AutoPilotProfileAssigned { get; set; }

    [JsonPropertyName("autoPilotRegistered")]
    public bool? AutoPilotRegistered { get; set; }

    [JsonPropertyName("azureAdJoinType")]
    public string? AzureAdJoinType { get; set; }

    [JsonPropertyName("azureAdRegistered")]
    public bool? AzureAdRegistered { get; set; }

    [JsonPropertyName("deviceName")]
    public string? DeviceName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("managedBy")]
    public string? ManagedBy { get; set; }

    [JsonPropertyName("manufacturer")]
    public string? Manufacturer { get; set; }

    [JsonPropertyName("model")]
    public string? Model { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("serialNumber")]
    public string? SerialNumber { get; set; }
}
