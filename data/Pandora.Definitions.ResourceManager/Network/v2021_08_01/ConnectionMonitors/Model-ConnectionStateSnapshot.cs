using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.ConnectionMonitors;


internal class ConnectionStateSnapshotModel
{
    [JsonPropertyName("avgLatencyInMs")]
    public int? AvgLatencyInMs { get; set; }

    [JsonPropertyName("connectionState")]
    public ConnectionStateConstant? ConnectionState { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("endTime")]
    public DateTime? EndTime { get; set; }

    [JsonPropertyName("evaluationState")]
    public EvaluationStateConstant? EvaluationState { get; set; }

    [JsonPropertyName("hops")]
    public List<ConnectivityHopModel>? Hops { get; set; }

    [JsonPropertyName("maxLatencyInMs")]
    public int? MaxLatencyInMs { get; set; }

    [JsonPropertyName("minLatencyInMs")]
    public int? MinLatencyInMs { get; set; }

    [JsonPropertyName("probesFailed")]
    public int? ProbesFailed { get; set; }

    [JsonPropertyName("probesSent")]
    public int? ProbesSent { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startTime")]
    public DateTime? StartTime { get; set; }
}
