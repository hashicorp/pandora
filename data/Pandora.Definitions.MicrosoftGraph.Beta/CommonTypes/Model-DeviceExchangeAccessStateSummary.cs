// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceExchangeAccessStateSummaryModel
{
    [JsonPropertyName("allowedDeviceCount")]
    public int? AllowedDeviceCount { get; set; }

    [JsonPropertyName("blockedDeviceCount")]
    public int? BlockedDeviceCount { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("quarantinedDeviceCount")]
    public int? QuarantinedDeviceCount { get; set; }

    [JsonPropertyName("unavailableDeviceCount")]
    public int? UnavailableDeviceCount { get; set; }

    [JsonPropertyName("unknownDeviceCount")]
    public int? UnknownDeviceCount { get; set; }
}
