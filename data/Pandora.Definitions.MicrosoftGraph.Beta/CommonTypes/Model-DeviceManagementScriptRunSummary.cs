// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceManagementScriptRunSummaryModel
{
    [JsonPropertyName("errorDeviceCount")]
    public int? ErrorDeviceCount { get; set; }

    [JsonPropertyName("errorUserCount")]
    public int? ErrorUserCount { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("successDeviceCount")]
    public int? SuccessDeviceCount { get; set; }

    [JsonPropertyName("successUserCount")]
    public int? SuccessUserCount { get; set; }
}
