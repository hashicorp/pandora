using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.StartStopManagedInstanceSchedules;


internal class ScheduleItemModel
{
    [JsonPropertyName("startDay")]
    [Required]
    public DayOfWeekConstant StartDay { get; set; }

    [JsonPropertyName("startTime")]
    [Required]
    public string StartTime { get; set; }

    [JsonPropertyName("stopDay")]
    [Required]
    public DayOfWeekConstant StopDay { get; set; }

    [JsonPropertyName("stopTime")]
    [Required]
    public string StopTime { get; set; }
}
