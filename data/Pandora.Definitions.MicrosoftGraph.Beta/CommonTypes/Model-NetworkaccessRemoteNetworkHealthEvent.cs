// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class NetworkaccessRemoteNetworkHealthEventModel
{
    [JsonPropertyName("bgpRoutesAdvertisedCount")]
    public int? BgpRoutesAdvertisedCount { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("destinationIp")]
    public string? DestinationIp { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("receivedBytes")]
    public int? ReceivedBytes { get; set; }

    [JsonPropertyName("remoteNetworkId")]
    public string? RemoteNetworkId { get; set; }

    [JsonPropertyName("sentBytes")]
    public int? SentBytes { get; set; }

    [JsonPropertyName("sourceIp")]
    public string? SourceIp { get; set; }

    [JsonPropertyName("status")]
    public NetworkaccessRemoteNetworkHealthEventStatusConstant? Status { get; set; }
}
