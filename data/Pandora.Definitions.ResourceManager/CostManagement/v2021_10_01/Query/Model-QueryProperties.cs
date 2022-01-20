using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.Query;


internal class QueryPropertiesModel
{
    [JsonPropertyName("columns")]
    public List<QueryColumnModel>? Columns { get; set; }

    [JsonPropertyName("nextLink")]
    public string? NextLink { get; set; }

    [JsonPropertyName("rows")]
    public List<List<object>>? Rows { get; set; }
}
