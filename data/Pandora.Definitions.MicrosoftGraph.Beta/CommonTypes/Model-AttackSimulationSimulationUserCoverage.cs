// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AttackSimulationSimulationUserCoverageModel
{
    [JsonPropertyName("attackSimulationUser")]
    public AttackSimulationUserModel? AttackSimulationUser { get; set; }

    [JsonPropertyName("clickCount")]
    public int? ClickCount { get; set; }

    [JsonPropertyName("compromisedCount")]
    public int? CompromisedCount { get; set; }

    [JsonPropertyName("latestSimulationDateTime")]
    public DateTime? LatestSimulationDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("simulationCount")]
    public int? SimulationCount { get; set; }
}
