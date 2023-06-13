using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_01_15.BackupResourceStorageConfigs;


internal class BackupResourceConfigModel
{
    [JsonPropertyName("crossRegionRestoreFlag")]
    public bool? CrossRegionRestoreFlag { get; set; }

    [JsonPropertyName("storageModelType")]
    public StorageTypeConstant? StorageModelType { get; set; }

    [JsonPropertyName("storageType")]
    public StorageTypeConstant? StorageType { get; set; }

    [JsonPropertyName("storageTypeState")]
    public StorageTypeStateConstant? StorageTypeState { get; set; }
}
