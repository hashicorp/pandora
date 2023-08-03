// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class CallRecordsMediaStreamModel
{
    [JsonPropertyName("audioCodec")]
    public AudioCodecConstant? AudioCodec { get; set; }

    [JsonPropertyName("averageAudioNetworkJitter")]
    public string? AverageAudioNetworkJitter { get; set; }

    [JsonPropertyName("averageBandwidthEstimate")]
    public long? AverageBandwidthEstimate { get; set; }

    [JsonPropertyName("averageJitter")]
    public string? AverageJitter { get; set; }

    [JsonPropertyName("averageRoundTripTime")]
    public string? AverageRoundTripTime { get; set; }

    [JsonPropertyName("endDateTime")]
    public DateTime? EndDateTime { get; set; }

    [JsonPropertyName("maxAudioNetworkJitter")]
    public string? MaxAudioNetworkJitter { get; set; }

    [JsonPropertyName("maxJitter")]
    public string? MaxJitter { get; set; }

    [JsonPropertyName("maxRoundTripTime")]
    public string? MaxRoundTripTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("packetUtilization")]
    public long? PacketUtilization { get; set; }

    [JsonPropertyName("startDateTime")]
    public DateTime? StartDateTime { get; set; }

    [JsonPropertyName("streamDirection")]
    public MediaStreamDirectionConstant? StreamDirection { get; set; }

    [JsonPropertyName("streamId")]
    public string? StreamId { get; set; }

    [JsonPropertyName("videoCodec")]
    public VideoCodecConstant? VideoCodec { get; set; }

    [JsonPropertyName("wasMediaBypassed")]
    public bool? WasMediaBypassed { get; set; }
}
