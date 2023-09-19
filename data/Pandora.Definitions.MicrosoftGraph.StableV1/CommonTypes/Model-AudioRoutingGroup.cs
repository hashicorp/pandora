// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class AudioRoutingGroupModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("receivers")]
    public List<string>? Receivers { get; set; }

    [JsonPropertyName("routingMode")]
    public AudioRoutingGroupRoutingModeConstant? RoutingMode { get; set; }

    [JsonPropertyName("sources")]
    public List<string>? Sources { get; set; }
}
