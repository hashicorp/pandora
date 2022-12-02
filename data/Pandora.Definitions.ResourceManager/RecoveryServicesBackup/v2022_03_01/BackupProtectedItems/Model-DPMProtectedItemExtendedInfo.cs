using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_03_01.BackupProtectedItems;


internal class DPMProtectedItemExtendedInfoModel
{
    [JsonPropertyName("diskStorageUsedInBytes")]
    public string? DiskStorageUsedInBytes { get; set; }

    [JsonPropertyName("isCollocated")]
    public bool? IsCollocated { get; set; }

    [JsonPropertyName("isPresentOnCloud")]
    public bool? IsPresentOnCloud { get; set; }

    [JsonPropertyName("lastBackupStatus")]
    public string? LastBackupStatus { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastRefreshedAt")]
    public DateTime? LastRefreshedAt { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("oldestRecoveryPoint")]
    public DateTime? OldestRecoveryPoint { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("onPremiseLatestRecoveryPoint")]
    public DateTime? OnPremiseLatestRecoveryPoint { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("onPremiseOldestRecoveryPoint")]
    public DateTime? OnPremiseOldestRecoveryPoint { get; set; }

    [JsonPropertyName("onPremiseRecoveryPointCount")]
    public int? OnPremiseRecoveryPointCount { get; set; }

    [JsonPropertyName("protectableObjectLoadPath")]
    public Dictionary<string, string>? ProtectableObjectLoadPath { get; set; }

    [JsonPropertyName("protected")]
    public bool? Protected { get; set; }

    [JsonPropertyName("protectionGroupName")]
    public string? ProtectionGroupName { get; set; }

    [JsonPropertyName("recoveryPointCount")]
    public int? RecoveryPointCount { get; set; }

    [JsonPropertyName("totalDiskStorageSizeInBytes")]
    public string? TotalDiskStorageSizeInBytes { get; set; }
}
