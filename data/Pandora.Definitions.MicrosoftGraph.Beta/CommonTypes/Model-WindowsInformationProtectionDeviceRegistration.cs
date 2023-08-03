// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WindowsInformationProtectionDeviceRegistrationModel
{
    [JsonPropertyName("deviceMacAddress")]
    public string? DeviceMacAddress { get; set; }

    [JsonPropertyName("deviceName")]
    public string? DeviceName { get; set; }

    [JsonPropertyName("deviceRegistrationId")]
    public string? DeviceRegistrationId { get; set; }

    [JsonPropertyName("deviceType")]
    public string? DeviceType { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastCheckInDateTime")]
    public DateTime? LastCheckInDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("userId")]
    public string? UserId { get; set; }
}
