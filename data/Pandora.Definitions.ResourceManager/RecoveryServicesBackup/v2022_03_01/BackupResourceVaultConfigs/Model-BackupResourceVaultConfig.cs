using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_03_01.BackupResourceVaultConfigs;


internal class BackupResourceVaultConfigModel
{
    [JsonPropertyName("enhancedSecurityState")]
    public EnhancedSecurityStateConstant? EnhancedSecurityState { get; set; }

    [JsonPropertyName("isSoftDeleteFeatureStateEditable")]
    public bool? IsSoftDeleteFeatureStateEditable { get; set; }

    [JsonPropertyName("resourceGuardOperationRequests")]
    public List<string>? ResourceGuardOperationRequests { get; set; }

    [JsonPropertyName("softDeleteFeatureState")]
    public SoftDeleteFeatureStateConstant? SoftDeleteFeatureState { get; set; }

    [JsonPropertyName("storageModelType")]
    public StorageTypeConstant? StorageModelType { get; set; }

    [JsonPropertyName("storageType")]
    public StorageTypeConstant? StorageType { get; set; }

    [JsonPropertyName("storageTypeState")]
    public StorageTypeStateConstant? StorageTypeState { get; set; }
}
