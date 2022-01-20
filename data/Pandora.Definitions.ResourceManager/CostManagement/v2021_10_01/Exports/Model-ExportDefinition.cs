using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.Exports;


internal class ExportDefinitionModel
{
    [JsonPropertyName("dataSet")]
    public ExportDatasetModel? DataSet { get; set; }

    [JsonPropertyName("timePeriod")]
    public ExportTimePeriodModel? TimePeriod { get; set; }

    [JsonPropertyName("timeframe")]
    [Required]
    public TimeframeTypeConstant Timeframe { get; set; }

    [JsonPropertyName("type")]
    [Required]
    public ExportTypeConstant Type { get; set; }
}
