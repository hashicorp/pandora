using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationProtectedItems;


internal class ReplicationProtectedItemPropertiesModel
{
    [JsonPropertyName("activeLocation")]
    public string? ActiveLocation { get; set; }

    [JsonPropertyName("allowedOperations")]
    public List<string>? AllowedOperations { get; set; }

    [JsonPropertyName("currentScenario")]
    public CurrentScenarioDetailsModel? CurrentScenario { get; set; }

    [JsonPropertyName("eventCorrelationId")]
    public string? EventCorrelationId { get; set; }

    [JsonPropertyName("failoverHealth")]
    public string? FailoverHealth { get; set; }

    [JsonPropertyName("failoverRecoveryPointId")]
    public string? FailoverRecoveryPointId { get; set; }

    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [JsonPropertyName("healthErrors")]
    public List<HealthErrorModel>? HealthErrors { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastSuccessfulFailoverTime")]
    public DateTime? LastSuccessfulFailoverTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastSuccessfulTestFailoverTime")]
    public DateTime? LastSuccessfulTestFailoverTime { get; set; }

    [JsonPropertyName("policyFriendlyName")]
    public string? PolicyFriendlyName { get; set; }

    [JsonPropertyName("policyId")]
    public string? PolicyId { get; set; }

    [JsonPropertyName("primaryFabricFriendlyName")]
    public string? PrimaryFabricFriendlyName { get; set; }

    [JsonPropertyName("primaryFabricProvider")]
    public string? PrimaryFabricProvider { get; set; }

    [JsonPropertyName("primaryProtectionContainerFriendlyName")]
    public string? PrimaryProtectionContainerFriendlyName { get; set; }

    [JsonPropertyName("protectableItemId")]
    public string? ProtectableItemId { get; set; }

    [JsonPropertyName("protectedItemType")]
    public string? ProtectedItemType { get; set; }

    [JsonPropertyName("protectionState")]
    public string? ProtectionState { get; set; }

    [JsonPropertyName("protectionStateDescription")]
    public string? ProtectionStateDescription { get; set; }

    [JsonPropertyName("providerSpecificDetails")]
    public ReplicationProviderSpecificSettingsModel? ProviderSpecificDetails { get; set; }

    [JsonPropertyName("recoveryContainerId")]
    public string? RecoveryContainerId { get; set; }

    [JsonPropertyName("recoveryFabricFriendlyName")]
    public string? RecoveryFabricFriendlyName { get; set; }

    [JsonPropertyName("recoveryFabricId")]
    public string? RecoveryFabricId { get; set; }

    [JsonPropertyName("recoveryProtectionContainerFriendlyName")]
    public string? RecoveryProtectionContainerFriendlyName { get; set; }

    [JsonPropertyName("recoveryServicesProviderId")]
    public string? RecoveryServicesProviderId { get; set; }

    [JsonPropertyName("replicationHealth")]
    public string? ReplicationHealth { get; set; }

    [JsonPropertyName("switchProviderState")]
    public string? SwitchProviderState { get; set; }

    [JsonPropertyName("switchProviderStateDescription")]
    public string? SwitchProviderStateDescription { get; set; }

    [JsonPropertyName("testFailoverState")]
    public string? TestFailoverState { get; set; }

    [JsonPropertyName("testFailoverStateDescription")]
    public string? TestFailoverStateDescription { get; set; }
}
