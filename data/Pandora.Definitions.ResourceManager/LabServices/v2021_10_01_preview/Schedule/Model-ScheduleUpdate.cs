using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.LabServices.v2021_10_01_preview.Schedule;


internal class ScheduleUpdateModel
{
    [JsonPropertyName("properties")]
    public ScheduleUpdatePropertiesModel? Properties { get; set; }
}
