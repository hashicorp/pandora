using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataProtection.v2022_05_01.AzureBackupJob;


internal class JobExtendedInfoModel
{
    [JsonPropertyName("additionalDetails")]
    public Dictionary<string, string>? AdditionalDetails { get; set; }

    [JsonPropertyName("backupInstanceState")]
    public string? BackupInstanceState { get; set; }

    [JsonPropertyName("dataTransferredInBytes")]
    public float? DataTransferredInBytes { get; set; }

    [JsonPropertyName("recoveryDestination")]
    public string? RecoveryDestination { get; set; }

    [JsonPropertyName("sourceRecoverPoint")]
    public RestoreJobRecoveryPointDetailsModel? SourceRecoverPoint { get; set; }

    [JsonPropertyName("subTasks")]
    public List<JobSubTaskModel>? SubTasks { get; set; }

    [JsonPropertyName("targetRecoverPoint")]
    public RestoreJobRecoveryPointDetailsModel? TargetRecoverPoint { get; set; }
}
