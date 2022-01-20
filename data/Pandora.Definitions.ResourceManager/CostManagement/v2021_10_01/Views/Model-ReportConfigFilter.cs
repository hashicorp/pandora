using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.Views;


internal class ReportConfigFilterModel
{
    [MinItems(2)]
    [JsonPropertyName("and")]
    public List<ReportConfigFilterModel>? And { get; set; }

    [JsonPropertyName("dimensions")]
    public ReportConfigComparisonExpressionModel? Dimensions { get; set; }

    [JsonPropertyName("not")]
    public ReportConfigFilterModel? Not { get; set; }

    [MinItems(2)]
    [JsonPropertyName("or")]
    public List<ReportConfigFilterModel>? Or { get; set; }

    [JsonPropertyName("tags")]
    public ReportConfigComparisonExpressionModel? Tags { get; set; }
}
