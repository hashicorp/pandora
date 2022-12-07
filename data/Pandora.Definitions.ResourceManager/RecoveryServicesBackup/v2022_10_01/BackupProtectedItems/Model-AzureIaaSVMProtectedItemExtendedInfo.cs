using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_10_01.BackupProtectedItems;


internal class AzureIaaSVMProtectedItemExtendedInfoModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("newestRecoveryPointInArchive")]
    public DateTime? NewestRecoveryPointInArchive { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("oldestRecoveryPoint")]
    public DateTime? OldestRecoveryPoint { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("oldestRecoveryPointInArchive")]
    public DateTime? OldestRecoveryPointInArchive { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("oldestRecoveryPointInVault")]
    public DateTime? OldestRecoveryPointInVault { get; set; }

    [JsonPropertyName("policyInconsistent")]
    public bool? PolicyInconsistent { get; set; }

    [JsonPropertyName("recoveryPointCount")]
    public int? RecoveryPointCount { get; set; }
}
