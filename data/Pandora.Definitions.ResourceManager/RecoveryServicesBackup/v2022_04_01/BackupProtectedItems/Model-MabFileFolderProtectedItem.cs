using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_04_01.BackupProtectedItems;

[ValueForType("MabFileFolderProtectedItem")]
internal class MabFileFolderProtectedItemModel : ProtectedItemModel
{
    [JsonPropertyName("computerName")]
    public string? ComputerName { get; set; }

    [JsonPropertyName("deferredDeleteSyncTimeInUTC")]
    public int? DeferredDeleteSyncTimeInUTC { get; set; }

    [JsonPropertyName("extendedInfo")]
    public MabFileFolderProtectedItemExtendedInfoModel? ExtendedInfo { get; set; }

    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [JsonPropertyName("lastBackupStatus")]
    public string? LastBackupStatus { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastBackupTime")]
    public DateTime? LastBackupTime { get; set; }

    [JsonPropertyName("protectionState")]
    public string? ProtectionState { get; set; }
}
