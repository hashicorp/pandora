// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceComplianceScriptDeviceStateModel
{
    [JsonPropertyName("detectionState")]
    public RunStateConstant? DetectionState { get; set; }

    [JsonPropertyName("expectedStateUpdateDateTime")]
    public DateTime? ExpectedStateUpdateDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastStateUpdateDateTime")]
    public DateTime? LastStateUpdateDateTime { get; set; }

    [JsonPropertyName("lastSyncDateTime")]
    public DateTime? LastSyncDateTime { get; set; }

    [JsonPropertyName("managedDevice")]
    public ManagedDeviceModel? ManagedDevice { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("scriptError")]
    public string? ScriptError { get; set; }

    [JsonPropertyName("scriptOutput")]
    public string? ScriptOutput { get; set; }
}
