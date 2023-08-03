// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class RemoteAssistanceSettingsModel
{
    [JsonPropertyName("allowSessionsToUnenrolledDevices")]
    public bool? AllowSessionsToUnenrolledDevices { get; set; }

    [JsonPropertyName("blockChat")]
    public bool? BlockChat { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("remoteAssistanceState")]
    public RemoteAssistanceStateConstant? RemoteAssistanceState { get; set; }
}
