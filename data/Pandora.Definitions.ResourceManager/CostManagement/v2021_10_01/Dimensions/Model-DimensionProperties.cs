using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.Dimensions;


internal class DimensionPropertiesModel
{
    [JsonPropertyName("category")]
    public string? Category { get; set; }

    [JsonPropertyName("data")]
    public List<string>? Data { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("filterEnabled")]
    public bool? FilterEnabled { get; set; }

    [JsonPropertyName("groupingEnabled")]
    public bool? GroupingEnabled { get; set; }

    [JsonPropertyName("nextLink")]
    public string? NextLink { get; set; }

    [JsonPropertyName("total")]
    public int? Total { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("usageEnd")]
    public DateTime? UsageEnd { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("usageStart")]
    public DateTime? UsageStart { get; set; }
}
