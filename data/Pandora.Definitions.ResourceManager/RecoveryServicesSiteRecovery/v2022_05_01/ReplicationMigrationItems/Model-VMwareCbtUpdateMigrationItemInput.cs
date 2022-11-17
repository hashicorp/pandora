using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_05_01.ReplicationMigrationItems;

[ValueForType("VMwareCbt")]
internal class VMwareCbtUpdateMigrationItemInputModel : UpdateMigrationItemProviderSpecificInputModel
{
    [JsonPropertyName("licenseType")]
    public LicenseTypeConstant? LicenseType { get; set; }

    [JsonPropertyName("performAutoResync")]
    public string? PerformAutoResync { get; set; }

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
    public string? TargetNetworkId { get; set; }

    [JsonPropertyName("targetNicTags")]
    public Dictionary<string, string>? TargetNicTags { get; set; }

    [JsonPropertyName("targetProximityPlacementGroupId")]
    public string? TargetProximityPlacementGroupId { get; set; }

    [JsonPropertyName("targetResourceGroupId")]
    public string? TargetResourceGroupId { get; set; }

    [JsonPropertyName("targetVmName")]
    public string? TargetVmName { get; set; }

    [JsonPropertyName("targetVmSize")]
    public string? TargetVmSize { get; set; }

    [JsonPropertyName("targetVmTags")]
    public Dictionary<string, string>? TargetVmTags { get; set; }

    [JsonPropertyName("testNetworkId")]
    public string? TestNetworkId { get; set; }

    [JsonPropertyName("vmDisks")]
    public List<VMwareCbtUpdateDiskInputModel>? VmDisks { get; set; }

    [JsonPropertyName("vmNics")]
    public List<VMwareCbtNicInputModel>? VmNics { get; set; }
}
