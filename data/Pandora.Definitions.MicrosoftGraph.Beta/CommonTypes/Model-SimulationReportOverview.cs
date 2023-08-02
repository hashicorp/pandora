// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SimulationReportOverviewModel
{
    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("recommendedActions")]
    public List<RecommendedActionModel>? RecommendedActions { get; set; }

    [JsonPropertyName("resolvedTargetsCount")]
    public int? ResolvedTargetsCount { get; set; }

    [JsonPropertyName("simulationEventsContent")]
    public SimulationEventsContentModel? SimulationEventsContent { get; set; }

    [JsonPropertyName("trainingEventsContent")]
    public TrainingEventsContentModel? TrainingEventsContent { get; set; }
}
