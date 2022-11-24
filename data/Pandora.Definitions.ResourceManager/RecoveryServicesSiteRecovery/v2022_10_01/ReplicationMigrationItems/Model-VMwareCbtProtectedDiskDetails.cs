using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationMigrationItems;


internal class VMwareCbtProtectedDiskDetailsModel
{
    [JsonPropertyName("capacityInBytes")]
    public int? CapacityInBytes { get; set; }

    [JsonPropertyName("diskEncryptionSetId")]
    public string? DiskEncryptionSetId { get; set; }

    [JsonPropertyName("diskId")]
    public string? DiskId { get; set; }

    [JsonPropertyName("diskName")]
    public string? DiskName { get; set; }

    [JsonPropertyName("diskPath")]
    public string? DiskPath { get; set; }

    [JsonPropertyName("diskType")]
    public DiskAccountTypeConstant? DiskType { get; set; }

    [JsonPropertyName("isOSDisk")]
    public string? IsOSDisk { get; set; }

    [JsonPropertyName("logStorageAccountId")]
    public string? LogStorageAccountId { get; set; }

    [JsonPropertyName("logStorageAccountSasSecretName")]
    public string? LogStorageAccountSasSecretName { get; set; }

    [JsonPropertyName("seedBlobUri")]
    public string? SeedBlobUri { get; set; }

    [JsonPropertyName("seedManagedDiskId")]
    public string? SeedManagedDiskId { get; set; }

    [JsonPropertyName("targetBlobUri")]
    public string? TargetBlobUri { get; set; }

    [JsonPropertyName("targetDiskName")]
    public string? TargetDiskName { get; set; }

    [JsonPropertyName("targetManagedDiskId")]
    public string? TargetManagedDiskId { get; set; }
}
