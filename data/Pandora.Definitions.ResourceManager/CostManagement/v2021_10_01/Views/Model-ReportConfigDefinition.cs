using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.Views
{

    internal class ReportConfigDefinitionModel
    {
        [JsonPropertyName("dataSet")]
        public ReportConfigDatasetModel? DataSet { get; set; }

        [JsonPropertyName("includeMonetaryCommitment")]
        public bool? IncludeMonetaryCommitment { get; set; }

        [JsonPropertyName("timePeriod")]
        public ReportConfigTimePeriodModel? TimePeriod { get; set; }

        [JsonPropertyName("timeframe")]
        [Required]
        public ReportTimeframeTypeConstant Timeframe { get; set; }

        [JsonPropertyName("type")]
        [Required]
        public ReportTypeConstant Type { get; set; }
    }
}
