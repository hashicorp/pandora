using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2021_12_01.BackupUsageSummaries;


internal class BackupManagementUsageModel
{
    [JsonPropertyName("currentValue")]
    public int? CurrentValue { get; set; }

    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    [JsonPropertyName("name")]
    public NameInfoModel? Name { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("nextResetTime")]
    public DateTime? NextResetTime { get; set; }

    [JsonPropertyName("quotaPeriod")]
    public string? QuotaPeriod { get; set; }

    [JsonPropertyName("unit")]
    public UsagesUnitConstant? Unit { get; set; }
}
