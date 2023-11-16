// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class NetworkaccessDestinationModel
{
    [JsonPropertyName("deviceCount")]
    public int? DeviceCount { get; set; }

    [JsonPropertyName("fqdn")]
    public string? Fqdn { get; set; }

    [JsonPropertyName("ip")]
    public string? Ip { get; set; }

    [JsonPropertyName("lastAccessDateTime")]
    public DateTime? LastAccessDateTime { get; set; }

    [JsonPropertyName("networkingProtocol")]
    public NetworkaccessDestinationNetworkingProtocolConstant? NetworkingProtocol { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("port")]
    public int? Port { get; set; }

    [JsonPropertyName("trafficType")]
    public NetworkaccessDestinationTrafficTypeConstant? TrafficType { get; set; }

    [JsonPropertyName("transactionCount")]
    public int? TransactionCount { get; set; }

    [JsonPropertyName("userCount")]
    public int? UserCount { get; set; }
}
