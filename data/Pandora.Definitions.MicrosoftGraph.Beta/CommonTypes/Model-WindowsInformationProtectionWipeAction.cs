// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WindowsInformationProtectionWipeActionModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastCheckInDateTime")]
    public DateTime? LastCheckInDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("status")]
    public WindowsInformationProtectionWipeActionStatusConstant? Status { get; set; }

    [JsonPropertyName("targetedDeviceMacAddress")]
    public string? TargetedDeviceMacAddress { get; set; }

    [JsonPropertyName("targetedDeviceName")]
    public string? TargetedDeviceName { get; set; }

    [JsonPropertyName("targetedDeviceRegistrationId")]
    public string? TargetedDeviceRegistrationId { get; set; }

    [JsonPropertyName("targetedUserId")]
    public string? TargetedUserId { get; set; }
}
