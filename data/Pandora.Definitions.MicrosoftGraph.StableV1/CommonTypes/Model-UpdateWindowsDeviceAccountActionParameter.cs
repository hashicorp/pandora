// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class UpdateWindowsDeviceAccountActionParameterModel
{
    [JsonPropertyName("calendarSyncEnabled")]
    public bool? CalendarSyncEnabled { get; set; }

    [JsonPropertyName("deviceAccount")]
    public WindowsDeviceAccountModel? DeviceAccount { get; set; }

    [JsonPropertyName("deviceAccountEmail")]
    public string? DeviceAccountEmail { get; set; }

    [JsonPropertyName("exchangeServer")]
    public string? ExchangeServer { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("passwordRotationEnabled")]
    public bool? PasswordRotationEnabled { get; set; }

    [JsonPropertyName("sessionInitiationProtocalAddress")]
    public string? SessionInitiationProtocalAddress { get; set; }
}
