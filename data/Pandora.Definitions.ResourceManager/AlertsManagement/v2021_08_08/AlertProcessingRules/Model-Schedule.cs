using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AlertsManagement.v2021_08_08.AlertProcessingRules;


internal class ScheduleModel
{
    [JsonPropertyName("effectiveFrom")]
    public string? EffectiveFrom { get; set; }

    [JsonPropertyName("effectiveUntil")]
    public string? EffectiveUntil { get; set; }

    [JsonPropertyName("recurrences")]
    public List<RecurrenceModel>? Recurrences { get; set; }

    [JsonPropertyName("timeZone")]
    public string? TimeZone { get; set; }
}
