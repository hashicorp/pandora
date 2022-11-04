using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.LabServices.v2022_08_01.Schedule;


internal class SchedulePropertiesModel
{
    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("recurrencePattern")]
    public RecurrencePatternModel? RecurrencePattern { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startAt")]
    public DateTime? StartAt { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("stopAt")]
    [Required]
    public DateTime StopAt { get; set; }

    [JsonPropertyName("timeZoneId")]
    [Required]
    public string TimeZoneId { get; set; }
}
