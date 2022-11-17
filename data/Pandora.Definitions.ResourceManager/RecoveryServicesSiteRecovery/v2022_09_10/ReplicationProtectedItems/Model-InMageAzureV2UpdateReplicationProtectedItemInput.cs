using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_09_10.ReplicationProtectedItems;

[ValueForType("InMageAzureV2")]
internal class InMageAzureV2UpdateReplicationProtectedItemInputModel : UpdateReplicationProtectedItemProviderInputModel
{
    [JsonPropertyName("recoveryAzureV1ResourceGroupId")]
    public string? RecoveryAzureV1ResourceGroupId { get; set; }

    [JsonPropertyName("recoveryAzureV2ResourceGroupId")]
    public string? RecoveryAzureV2ResourceGroupId { get; set; }

    [JsonPropertyName("sqlServerLicenseType")]
    public SqlServerLicenseTypeConstant? SqlServerLicenseType { get; set; }

    [JsonPropertyName("targetAvailabilityZone")]
    public string? TargetAvailabilityZone { get; set; }

    [JsonPropertyName("targetManagedDiskTags")]
    public Dictionary<string, string>? TargetManagedDiskTags { get; set; }

    [JsonPropertyName("targetNicTags")]
    public Dictionary<string, string>? TargetNicTags { get; set; }

    [JsonPropertyName("targetProximityPlacementGroupId")]
    public string? TargetProximityPlacementGroupId { get; set; }

    [JsonPropertyName("targetVmTags")]
    public Dictionary<string, string>? TargetVmTags { get; set; }

    [JsonPropertyName("useManagedDisks")]
    public string? UseManagedDisks { get; set; }

    [JsonPropertyName("vmDisks")]
    public List<UpdateDiskInputModel>? VmDisks { get; set; }
}
