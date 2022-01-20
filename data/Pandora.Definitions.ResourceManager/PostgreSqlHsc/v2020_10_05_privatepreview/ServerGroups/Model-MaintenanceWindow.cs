using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.PostgreSqlHsc.v2020_10_05_privatepreview.ServerGroups;


internal class MaintenanceWindowModel
{
    [JsonPropertyName("customWindow")]
    public string? CustomWindow { get; set; }

    [JsonPropertyName("dayOfWeek")]
    public int? DayOfWeek { get; set; }

    [JsonPropertyName("startHour")]
    public int? StartHour { get; set; }

    [JsonPropertyName("startMinute")]
    public int? StartMinute { get; set; }
}
