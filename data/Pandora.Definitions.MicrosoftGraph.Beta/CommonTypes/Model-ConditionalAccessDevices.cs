// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ConditionalAccessDevicesModel
{
    [JsonPropertyName("deviceFilter")]
    public ConditionalAccessFilterModel? DeviceFilter { get; set; }

    [JsonPropertyName("excludeDeviceStates")]
    public List<string>? ExcludeDeviceStates { get; set; }

    [JsonPropertyName("excludeDevices")]
    public List<string>? ExcludeDevices { get; set; }

    [JsonPropertyName("includeDeviceStates")]
    public List<string>? IncludeDeviceStates { get; set; }

    [JsonPropertyName("includeDevices")]
    public List<string>? IncludeDevices { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
