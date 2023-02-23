using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetApp.v2022_09_01.BackupPolicy;


internal class BackupPolicyPropertiesModel
{
    [JsonPropertyName("backupPolicyId")]
    public string? BackupPolicyId { get; set; }

    [JsonPropertyName("dailyBackupsToKeep")]
    public int? DailyBackupsToKeep { get; set; }

    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    [JsonPropertyName("monthlyBackupsToKeep")]
    public int? MonthlyBackupsToKeep { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("volumeBackups")]
    public List<VolumeBackupsModel>? VolumeBackups { get; set; }

    [JsonPropertyName("volumesAssigned")]
    public int? VolumesAssigned { get; set; }

    [JsonPropertyName("weeklyBackupsToKeep")]
    public int? WeeklyBackupsToKeep { get; set; }
}
