using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.ReservedInstances;


internal class ReportURLModel
{
    [JsonPropertyName("reportUrl")]
    public string? ReportUrl { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("validUntil")]
    public DateTime? ValidUntil { get; set; }
}
