using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.Views;


internal class ReportConfigSortingModel
{
    [JsonPropertyName("direction")]
    public DirectionConstant? Direction { get; set; }

    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }
}
