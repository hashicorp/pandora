// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class AttackSimulationRootModel
{
    [JsonPropertyName("endUserNotifications")]
    public List<EndUserNotificationModel>? EndUserNotifications { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("landingPages")]
    public List<LandingPageModel>? LandingPages { get; set; }

    [JsonPropertyName("loginPages")]
    public List<LoginPageModel>? LoginPages { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("operations")]
    public List<AttackSimulationOperationModel>? Operations { get; set; }

    [JsonPropertyName("payloads")]
    public List<PayloadModel>? Payloads { get; set; }

    [JsonPropertyName("simulationAutomations")]
    public List<SimulationAutomationModel>? SimulationAutomations { get; set; }

    [JsonPropertyName("simulations")]
    public List<SimulationModel>? Simulations { get; set; }

    [JsonPropertyName("trainings")]
    public List<TrainingModel>? Trainings { get; set; }
}
