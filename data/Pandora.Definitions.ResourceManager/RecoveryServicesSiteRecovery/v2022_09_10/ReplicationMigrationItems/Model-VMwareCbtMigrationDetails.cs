using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_09_10.ReplicationMigrationItems;

[ValueForType("VMwareCbt")]
internal class VMwareCbtMigrationDetailsModel : MigrationProviderSpecificSettingsModel
{
    [JsonPropertyName("dataMoverRunAsAccountId")]
    public string? DataMoverRunAsAccountId { get; set; }

    [JsonPropertyName("firmwareType")]
    public string? FirmwareType { get; set; }

    [JsonPropertyName("initialSeedingProgressPercentage")]
    public int? InitialSeedingProgressPercentage { get; set; }

    [JsonPropertyName("initialSeedingRetryCount")]
    public int? InitialSeedingRetryCount { get; set; }

    [JsonPropertyName("lastRecoveryPointId")]
    public string? LastRecoveryPointId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastRecoveryPointReceived")]
    public DateTime? LastRecoveryPointReceived { get; set; }

    [JsonPropertyName("licenseType")]
    public string? LicenseType { get; set; }

    [JsonPropertyName("migrationProgressPercentage")]
    public int? MigrationProgressPercentage { get; set; }

    [JsonPropertyName("migrationRecoveryPointId")]
    public string? MigrationRecoveryPointId { get; set; }

    [JsonPropertyName("osType")]
    public string? OsType { get; set; }

    [JsonPropertyName("performAutoResync")]
    public string? PerformAutoResync { get; set; }

    [JsonPropertyName("protectedDisks")]
    public List<VMwareCbtProtectedDiskDetailsModel>? ProtectedDisks { get; set; }

    [JsonPropertyName("resumeProgressPercentage")]
    public int? ResumeProgressPercentage { get; set; }

    [JsonPropertyName("resumeRetryCount")]
    public int? ResumeRetryCount { get; set; }

    [JsonPropertyName("resyncProgressPercentage")]
    public int? ResyncProgressPercentage { get; set; }

    [JsonPropertyName("resyncRequired")]
    public string? ResyncRequired { get; set; }

    [JsonPropertyName("resyncRetryCount")]
    public int? ResyncRetryCount { get; set; }

    [JsonPropertyName("resyncState")]
    public ResyncStateConstant? ResyncState { get; set; }

    [JsonPropertyName("seedDiskTags")]
    public Dictionary<string, string>? SeedDiskTags { get; set; }

    [JsonPropertyName("snapshotRunAsAccountId")]
    public string? SnapshotRunAsAccountId { get; set; }

    [JsonPropertyName("sqlServerLicenseType")]
    public string? SqlServerLicenseType { get; set; }

    [JsonPropertyName("storageAccountId")]
    public string? StorageAccountId { get; set; }

    [JsonPropertyName("targetAvailabilitySetId")]
    public string? TargetAvailabilitySetId { get; set; }

    [JsonPropertyName("targetAvailabilityZone")]
    public string? TargetAvailabilityZone { get; set; }

    [JsonPropertyName("targetBootDiagnosticsStorageAccountId")]
    public string? TargetBootDiagnosticsStorageAccountId { get; set; }

    [JsonPropertyName("targetDiskTags")]
    public Dictionary<string, string>? TargetDiskTags { get; set; }

    [JsonPropertyName("targetGeneration")]
    public string? TargetGeneration { get; set; }

    [JsonPropertyName("targetLocation")]
    public string? TargetLocation { get; set; }

    [JsonPropertyName("targetNetworkId")]
    public string? TargetNetworkId { get; set; }

    [JsonPropertyName("targetNicTags")]
    public Dictionary<string, string>? TargetNicTags { get; set; }

    [JsonPropertyName("targetProximityPlacementGroupId")]
    public string? TargetProximityPlacementGroupId { get; set; }

    [JsonPropertyName("targetResourceGroupId")]
    public string? TargetResourceGroupId { get; set; }

    [JsonPropertyName("targetVmName")]
    public string? TargetVMName { get; set; }

    [JsonPropertyName("targetVmSize")]
    public string? TargetVMSize { get; set; }

    [JsonPropertyName("targetVmTags")]
    public Dictionary<string, string>? TargetVMTags { get; set; }

    [JsonPropertyName("testNetworkId")]
    public string? TestNetworkId { get; set; }

    [JsonPropertyName("vmNics")]
    public List<VMwareCbtNicDetailsModel>? VMNics { get; set; }

    [JsonPropertyName("vmwareMachineId")]
    public string? VMwareMachineId { get; set; }
}
