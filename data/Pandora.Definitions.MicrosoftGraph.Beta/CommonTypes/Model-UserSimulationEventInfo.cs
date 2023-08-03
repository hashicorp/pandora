// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class UserSimulationEventInfoModel
{
    [JsonPropertyName("browser")]
    public string? Browser { get; set; }

    [JsonPropertyName("eventDateTime")]
    public DateTime? EventDateTime { get; set; }

    [JsonPropertyName("eventName")]
    public string? EventName { get; set; }

    [JsonPropertyName("ipAddress")]
    public string? IpAddress { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("osPlatformDeviceDetails")]
    public string? OsPlatformDeviceDetails { get; set; }
}
