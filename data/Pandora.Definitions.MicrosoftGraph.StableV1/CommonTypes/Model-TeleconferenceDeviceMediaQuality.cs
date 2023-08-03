// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class TeleconferenceDeviceMediaQualityModel
{
    [JsonPropertyName("averageInboundJitter")]
    public string? AverageInboundJitter { get; set; }

    [JsonPropertyName("averageInboundRoundTripDelay")]
    public string? AverageInboundRoundTripDelay { get; set; }

    [JsonPropertyName("averageOutboundJitter")]
    public string? AverageOutboundJitter { get; set; }

    [JsonPropertyName("averageOutboundRoundTripDelay")]
    public string? AverageOutboundRoundTripDelay { get; set; }

    [JsonPropertyName("channelIndex")]
    public int? ChannelIndex { get; set; }

    [JsonPropertyName("inboundPackets")]
    public long? InboundPackets { get; set; }

    [JsonPropertyName("localIPAddress")]
    public string? LocalIPAddress { get; set; }

    [JsonPropertyName("localPort")]
    public int? LocalPort { get; set; }

    [JsonPropertyName("maximumInboundJitter")]
    public string? MaximumInboundJitter { get; set; }

    [JsonPropertyName("maximumInboundRoundTripDelay")]
    public string? MaximumInboundRoundTripDelay { get; set; }

    [JsonPropertyName("maximumOutboundJitter")]
    public string? MaximumOutboundJitter { get; set; }

    [JsonPropertyName("maximumOutboundRoundTripDelay")]
    public string? MaximumOutboundRoundTripDelay { get; set; }

    [JsonPropertyName("mediaDuration")]
    public string? MediaDuration { get; set; }

    [JsonPropertyName("networkLinkSpeedInBytes")]
    public long? NetworkLinkSpeedInBytes { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("outboundPackets")]
    public long? OutboundPackets { get; set; }

    [JsonPropertyName("remoteIPAddress")]
    public string? RemoteIPAddress { get; set; }

    [JsonPropertyName("remotePort")]
    public int? RemotePort { get; set; }
}
