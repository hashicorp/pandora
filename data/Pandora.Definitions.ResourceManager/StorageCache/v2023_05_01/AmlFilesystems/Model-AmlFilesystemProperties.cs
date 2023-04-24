using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageCache.v2023_05_01.AmlFilesystems;


internal class AmlFilesystemPropertiesModel
{
    [JsonPropertyName("clientInfo")]
    public AmlFilesystemClientInfoModel? ClientInfo { get; set; }

    [JsonPropertyName("encryptionSettings")]
    public AmlFilesystemEncryptionSettingsModel? EncryptionSettings { get; set; }

    [JsonPropertyName("filesystemSubnet")]
    [Required]
    public string FilesystemSubnet { get; set; }

    [JsonPropertyName("health")]
    public AmlFilesystemHealthModel? Health { get; set; }

    [JsonPropertyName("hsm")]
    public AmlFilesystemPropertiesHsmModel? Hsm { get; set; }

    [JsonPropertyName("maintenanceWindow")]
    [Required]
    public AmlFilesystemPropertiesMaintenanceWindowModel MaintenanceWindow { get; set; }

    [JsonPropertyName("provisioningState")]
    public AmlFilesystemProvisioningStateTypeConstant? ProvisioningState { get; set; }

    [JsonPropertyName("storageCapacityTiB")]
    [Required]
    public float StorageCapacityTiB { get; set; }

    [JsonPropertyName("throughputProvisionedMBps")]
    public int? ThroughputProvisionedMBps { get; set; }
}
