using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationMigrationItems;

[ValueForType("VMwareCbt")]
internal class VMwareCbtEnableMigrationInputModel : EnableMigrationProviderSpecificInputModel
{
    [JsonPropertyName("dataMoverRunAsAccountId")]
    [Required]
    public string DataMoverRunAsAccountId { get; set; }

    [JsonPropertyName("disksToInclude")]
    [Required]
    public List<VMwareCbtDiskInputModel> DisksToInclude { get; set; }

    [JsonPropertyName("licenseType")]
    public LicenseTypeConstant? LicenseType { get; set; }

    [JsonPropertyName("performAutoResync")]
    public string? PerformAutoResync { get; set; }

    [JsonPropertyName("performSqlBulkRegistration")]
    public string? PerformSqlBulkRegistration { get; set; }

    [JsonPropertyName("seedDiskTags")]
    public Dictionary<string, string>? SeedDiskTags { get; set; }

    [JsonPropertyName("snapshotRunAsAccountId")]
    [Required]
    public string SnapshotRunAsAccountId { get; set; }

    [JsonPropertyName("sqlServerLicenseType")]
    public SqlServerLicenseTypeConstant? SqlServerLicenseType { get; set; }

    [JsonPropertyName("targetAvailabilitySetId")]
    public string? TargetAvailabilitySetId { get; set; }

    [JsonPropertyName("targetAvailabilityZone")]
    public string? TargetAvailabilityZone { get; set; }

    [JsonPropertyName("targetBootDiagnosticsStorageAccountId")]
    public string? TargetBootDiagnosticsStorageAccountId { get; set; }

    [JsonPropertyName("targetDiskTags")]
    public Dictionary<string, string>? TargetDiskTags { get; set; }

    [JsonPropertyName("targetNetworkId")]
    [Required]
    public string TargetNetworkId { get; set; }

    [JsonPropertyName("targetNicTags")]
    public Dictionary<string, string>? TargetNicTags { get; set; }

    [JsonPropertyName("targetProximityPlacementGroupId")]
    public string? TargetProximityPlacementGroupId { get; set; }

    [JsonPropertyName("targetResourceGroupId")]
    [Required]
    public string TargetResourceGroupId { get; set; }

    [JsonPropertyName("targetSubnetName")]
    public string? TargetSubnetName { get; set; }

    [JsonPropertyName("targetVmName")]
    public string? TargetVMName { get; set; }

    [JsonPropertyName("targetVmSize")]
    public string? TargetVMSize { get; set; }

    [JsonPropertyName("targetVmTags")]
    public Dictionary<string, string>? TargetVMTags { get; set; }

    [JsonPropertyName("testNetworkId")]
    public string? TestNetworkId { get; set; }

    [JsonPropertyName("testSubnetName")]
    public string? TestSubnetName { get; set; }

    [JsonPropertyName("vmwareMachineId")]
    [Required]
    public string VMwareMachineId { get; set; }
}
