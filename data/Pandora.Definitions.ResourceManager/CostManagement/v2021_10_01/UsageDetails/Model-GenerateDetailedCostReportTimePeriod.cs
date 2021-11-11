using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.UsageDetails
{

    internal class GenerateDetailedCostReportTimePeriodModel
    {
        [JsonPropertyName("end")]
        [Required]
        public string End { get; set; }

        [JsonPropertyName("start")]
        [Required]
        public string Start { get; set; }
    }
}
