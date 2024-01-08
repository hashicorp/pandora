using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataProtection.v2023_12_01.BackupVaults;


internal class BackupVaultModel
{
    [JsonPropertyName("featureSettings")]
    public FeatureSettingsModel? FeatureSettings { get; set; }

    [JsonPropertyName("isVaultProtectedByResourceGuard")]
    public bool? IsVaultProtectedByResourceGuard { get; set; }

    [JsonPropertyName("monitoringSettings")]
    public MonitoringSettingsModel? MonitoringSettings { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("replicatedRegions")]
    public List<string>? ReplicatedRegions { get; set; }

    [JsonPropertyName("resourceMoveDetails")]
    public ResourceMoveDetailsModel? ResourceMoveDetails { get; set; }

    [JsonPropertyName("resourceMoveState")]
    public ResourceMoveStateConstant? ResourceMoveState { get; set; }

    [JsonPropertyName("secureScore")]
    public SecureScoreLevelConstant? SecureScore { get; set; }

    [JsonPropertyName("securitySettings")]
    public SecuritySettingsModel? SecuritySettings { get; set; }

    [JsonPropertyName("storageSettings")]
    [Required]
    public List<StorageSettingModel> StorageSettings { get; set; }
}
