// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class SecurityModel
{
    [JsonPropertyName("alerts")]
    public List<AlertModel>? Alerts { get; set; }

    [JsonPropertyName("alerts_v2")]
    public List<AlertModel>? Alertsv2 { get; set; }

    [JsonPropertyName("attackSimulation")]
    public AttackSimulationRootModel? AttackSimulation { get; set; }

    [JsonPropertyName("cases")]
    public CasesRootModel? Cases { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("incidents")]
    public List<IncidentModel>? Incidents { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("secureScoreControlProfiles")]
    public List<SecureScoreControlProfileModel>? SecureScoreControlProfiles { get; set; }

    [JsonPropertyName("secureScores")]
    public List<SecureScoreModel>? SecureScores { get; set; }

    [JsonPropertyName("triggerTypes")]
    public TriggerTypesRootModel? TriggerTypes { get; set; }

    [JsonPropertyName("triggers")]
    public TriggersRootModel? Triggers { get; set; }
}
