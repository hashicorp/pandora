using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_09_10.ReplicationRecoveryPlans;


internal class RecoveryPlanPropertiesModel
{
    [JsonPropertyName("allowedOperations")]
    public List<string>? AllowedOperations { get; set; }

    [JsonPropertyName("currentScenario")]
    public CurrentScenarioDetailsModel? CurrentScenario { get; set; }

    [JsonPropertyName("currentScenarioStatus")]
    public string? CurrentScenarioStatus { get; set; }

    [JsonPropertyName("currentScenarioStatusDescription")]
    public string? CurrentScenarioStatusDescription { get; set; }

    [JsonPropertyName("failoverDeploymentModel")]
    public string? FailoverDeploymentModel { get; set; }

    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [JsonPropertyName("groups")]
    public List<RecoveryPlanGroupModel>? Groups { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastPlannedFailoverTime")]
    public DateTime? LastPlannedFailoverTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastTestFailoverTime")]
    public DateTime? LastTestFailoverTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastUnplannedFailoverTime")]
    public DateTime? LastUnplannedFailoverTime { get; set; }

    [JsonPropertyName("primaryFabricFriendlyName")]
    public string? PrimaryFabricFriendlyName { get; set; }

    [JsonPropertyName("primaryFabricId")]
    public string? PrimaryFabricId { get; set; }

    [JsonPropertyName("providerSpecificDetails")]
    public List<RecoveryPlanProviderSpecificDetailsModel>? ProviderSpecificDetails { get; set; }

    [JsonPropertyName("recoveryFabricFriendlyName")]
    public string? RecoveryFabricFriendlyName { get; set; }

    [JsonPropertyName("recoveryFabricId")]
    public string? RecoveryFabricId { get; set; }

    [JsonPropertyName("replicationProviders")]
    public List<string>? ReplicationProviders { get; set; }
}
