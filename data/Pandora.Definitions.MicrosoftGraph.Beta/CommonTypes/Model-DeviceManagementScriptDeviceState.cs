// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceManagementScriptDeviceStateModel
{
    [JsonPropertyName("errorCode")]
    public int? ErrorCode { get; set; }

    [JsonPropertyName("errorDescription")]
    public string? ErrorDescription { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastStateUpdateDateTime")]
    public DateTime? LastStateUpdateDateTime { get; set; }

    [JsonPropertyName("managedDevice")]
    public ManagedDeviceModel? ManagedDevice { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("resultMessage")]
    public string? ResultMessage { get; set; }

    [JsonPropertyName("runState")]
    public DeviceManagementScriptDeviceStateRunStateConstant? RunState { get; set; }
}
