using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.DataFlowDebugSession;


internal class DataFlowDebugSessionInfoModel
{
    [JsonPropertyName("computeType")]
    public string? ComputeType { get; set; }

    [JsonPropertyName("coreCount")]
    public int? CoreCount { get; set; }

    [JsonPropertyName("dataFlowName")]
    public string? DataFlowName { get; set; }

    [JsonPropertyName("integrationRuntimeName")]
    public string? IntegrationRuntimeName { get; set; }

    [JsonPropertyName("lastActivityTime")]
    public string? LastActivityTime { get; set; }

    [JsonPropertyName("nodeCount")]
    public int? NodeCount { get; set; }

    [JsonPropertyName("sessionId")]
    public string? SessionId { get; set; }

    [JsonPropertyName("startTime")]
    public string? StartTime { get; set; }

    [JsonPropertyName("timeToLiveInMinutes")]
    public int? TimeToLiveInMinutes { get; set; }
}
