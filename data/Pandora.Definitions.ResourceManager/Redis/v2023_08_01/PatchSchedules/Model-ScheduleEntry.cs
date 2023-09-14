using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Redis.v2023_08_01.PatchSchedules;


internal class ScheduleEntryModel
{
    [JsonPropertyName("dayOfWeek")]
    [Required]
    public DayOfWeekConstant DayOfWeek { get; set; }

    [JsonPropertyName("maintenanceWindow")]
    public string? MaintenanceWindow { get; set; }

    [JsonPropertyName("startHourUtc")]
    [Required]
    public int StartHourUtc { get; set; }
}
