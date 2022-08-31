using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SqlVirtualMachine.v2022_02_01.SqlVirtualMachines;


internal class AutoBackupSettingsModel
{
    [JsonPropertyName("backupScheduleType")]
    public BackupScheduleTypeConstant? BackupScheduleType { get; set; }

    [JsonPropertyName("backupSystemDbs")]
    public bool? BackupSystemDbs { get; set; }

    [JsonPropertyName("daysOfWeek")]
    public List<AutoBackupDaysOfWeekConstant>? DaysOfWeek { get; set; }

    [JsonPropertyName("enable")]
    public bool? Enable { get; set; }

    [JsonPropertyName("enableEncryption")]
    public bool? EnableEncryption { get; set; }

    [JsonPropertyName("fullBackupFrequency")]
    public FullBackupFrequencyTypeConstant? FullBackupFrequency { get; set; }

    [JsonPropertyName("fullBackupStartTime")]
    public int? FullBackupStartTime { get; set; }

    [JsonPropertyName("fullBackupWindowHours")]
    public int? FullBackupWindowHours { get; set; }

    [JsonPropertyName("logBackupFrequency")]
    public int? LogBackupFrequency { get; set; }

    [JsonPropertyName("password")]
    public string? Password { get; set; }

    [JsonPropertyName("retentionPeriod")]
    public int? RetentionPeriod { get; set; }

    [JsonPropertyName("storageAccessKey")]
    public string? StorageAccessKey { get; set; }

    [JsonPropertyName("storageAccountUrl")]
    public string? StorageAccountUrl { get; set; }

    [JsonPropertyName("storageContainerName")]
    public string? StorageContainerName { get; set; }
}
