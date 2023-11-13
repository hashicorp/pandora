using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.WebApps;


internal class BackupScheduleModel
{
    [JsonPropertyName("frequencyInterval")]
    [Required]
    public int FrequencyInterval { get; set; }

    [JsonPropertyName("frequencyUnit")]
    [Required]
    public FrequencyUnitConstant FrequencyUnit { get; set; }

    [JsonPropertyName("keepAtLeastOneBackup")]
    [Required]
    public bool KeepAtLeastOneBackup { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastExecutionTime")]
    public DateTime? LastExecutionTime { get; set; }

    [JsonPropertyName("retentionPeriodInDays")]
    [Required]
    public int RetentionPeriodInDays { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startTime")]
    public DateTime? StartTime { get; set; }
}
