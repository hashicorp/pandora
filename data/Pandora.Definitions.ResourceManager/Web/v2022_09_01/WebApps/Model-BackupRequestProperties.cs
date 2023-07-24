using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.WebApps;


internal class BackupRequestPropertiesModel
{
    [JsonPropertyName("backupName")]
    public string? BackupName { get; set; }

    [JsonPropertyName("backupSchedule")]
    public BackupScheduleModel? BackupSchedule { get; set; }

    [JsonPropertyName("databases")]
    public List<DatabaseBackupSettingModel>? Databases { get; set; }

    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    [JsonPropertyName("storageAccountUrl")]
    [Required]
    public string StorageAccountUrl { get; set; }
}
