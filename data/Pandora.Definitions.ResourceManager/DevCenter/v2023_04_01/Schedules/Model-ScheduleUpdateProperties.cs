using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevCenter.v2023_04_01.Schedules;


internal class ScheduleUpdatePropertiesModel
{
    [JsonPropertyName("frequency")]
    public ScheduledFrequencyConstant? Frequency { get; set; }

    [JsonPropertyName("state")]
    public ScheduleEnableStatusConstant? State { get; set; }

    [JsonPropertyName("time")]
    public string? Time { get; set; }

    [JsonPropertyName("timeZone")]
    public string? TimeZone { get; set; }

    [JsonPropertyName("type")]
    public ScheduledTypeConstant? Type { get; set; }
}
