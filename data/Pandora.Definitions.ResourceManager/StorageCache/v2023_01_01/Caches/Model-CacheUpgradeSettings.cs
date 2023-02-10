using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageCache.v2023_01_01.Caches;


internal class CacheUpgradeSettingsModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("scheduledTime")]
    public DateTime? ScheduledTime { get; set; }

    [JsonPropertyName("upgradeScheduleEnabled")]
    public bool? UpgradeScheduleEnabled { get; set; }
}
