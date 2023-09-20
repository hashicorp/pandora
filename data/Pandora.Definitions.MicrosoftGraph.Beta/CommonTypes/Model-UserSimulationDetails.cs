// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class UserSimulationDetailsModel
{
    [JsonPropertyName("assignedTrainingsCount")]
    public int? AssignedTrainingsCount { get; set; }

    [JsonPropertyName("completedTrainingsCount")]
    public int? CompletedTrainingsCount { get; set; }

    [JsonPropertyName("compromisedDateTime")]
    public DateTime? CompromisedDateTime { get; set; }

    [JsonPropertyName("inProgressTrainingsCount")]
    public int? InProgressTrainingsCount { get; set; }

    [JsonPropertyName("isCompromised")]
    public bool? IsCompromised { get; set; }

    [JsonPropertyName("latestSimulationActivity")]
    public string? LatestSimulationActivity { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("reportedPhishDateTime")]
    public DateTime? ReportedPhishDateTime { get; set; }

    [JsonPropertyName("simulationEvents")]
    public List<UserSimulationEventInfoModel>? SimulationEvents { get; set; }

    [JsonPropertyName("simulationUser")]
    public AttackSimulationUserModel? SimulationUser { get; set; }

    [JsonPropertyName("trainingEvents")]
    public List<UserTrainingEventInfoModel>? TrainingEvents { get; set; }
}
