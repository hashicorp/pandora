// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class IpApplicationSegmentModel
{
    [JsonPropertyName("destinationHost")]
    public string? DestinationHost { get; set; }

    [JsonPropertyName("destinationType")]
    public IpApplicationSegmentDestinationTypeConstant? DestinationType { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("port")]
    public int? Port { get; set; }

    [JsonPropertyName("ports")]
    public List<string>? Ports { get; set; }

    [JsonPropertyName("protocol")]
    public IpApplicationSegmentProtocolConstant? Protocol { get; set; }
}
