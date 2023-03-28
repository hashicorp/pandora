using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_02_02_preview.MaintenanceConfigurations;


internal class MaintenanceWindowModel
{
    [JsonPropertyName("durationHours")]
    [Required]
    public int DurationHours { get; set; }

    [JsonPropertyName("notAllowedDates")]
    public List<DateSpanModel>? NotAllowedDates { get; set; }

    [JsonPropertyName("schedule")]
    [Required]
    public ScheduleModel Schedule { get; set; }

    [JsonPropertyName("startDate")]
    public string? StartDate { get; set; }

    [JsonPropertyName("startTime")]
    [Required]
    public string StartTime { get; set; }

    [JsonPropertyName("utcOffset")]
    public string? UtcOffset { get; set; }
}
