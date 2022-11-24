using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationMigrationItems;


internal class MigrationItemPropertiesModel
{
    [JsonPropertyName("allowedOperations")]
    public List<MigrationItemOperationConstant>? AllowedOperations { get; set; }

    [JsonPropertyName("criticalJobHistory")]
    public List<CriticalJobHistoryDetailsModel>? CriticalJobHistory { get; set; }

    [JsonPropertyName("currentJob")]
    public CurrentJobDetailsModel? CurrentJob { get; set; }

    [JsonPropertyName("eventCorrelationId")]
    public string? EventCorrelationId { get; set; }

    [JsonPropertyName("health")]
    public ProtectionHealthConstant? Health { get; set; }

    [JsonPropertyName("healthErrors")]
    public List<HealthErrorModel>? HealthErrors { get; set; }

    [JsonPropertyName("lastMigrationStatus")]
    public string? LastMigrationStatus { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastMigrationTime")]
    public DateTime? LastMigrationTime { get; set; }

    [JsonPropertyName("lastTestMigrationStatus")]
    public string? LastTestMigrationStatus { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastTestMigrationTime")]
    public DateTime? LastTestMigrationTime { get; set; }

    [JsonPropertyName("machineName")]
    public string? MachineName { get; set; }

    [JsonPropertyName("migrationState")]
    public MigrationStateConstant? MigrationState { get; set; }

    [JsonPropertyName("migrationStateDescription")]
    public string? MigrationStateDescription { get; set; }

    [JsonPropertyName("policyFriendlyName")]
    public string? PolicyFriendlyName { get; set; }

    [JsonPropertyName("policyId")]
    public string? PolicyId { get; set; }

    [JsonPropertyName("providerSpecificDetails")]
    public MigrationProviderSpecificSettingsModel? ProviderSpecificDetails { get; set; }

    [JsonPropertyName("recoveryServicesProviderId")]
    public string? RecoveryServicesProviderId { get; set; }

    [JsonPropertyName("replicationStatus")]
    public string? ReplicationStatus { get; set; }

    [JsonPropertyName("testMigrateState")]
    public TestMigrationStateConstant? TestMigrateState { get; set; }

    [JsonPropertyName("testMigrateStateDescription")]
    public string? TestMigrateStateDescription { get; set; }
}
