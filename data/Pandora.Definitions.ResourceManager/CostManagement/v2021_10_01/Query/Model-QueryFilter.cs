using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.Query
{

    internal class QueryFilterModel
    {
        [MinItems(2)]
        [JsonPropertyName("and")]
        public List<QueryFilterModel>? And { get; set; }

        [JsonPropertyName("dimension")]
        public QueryComparisonExpressionModel? Dimension { get; set; }

        [JsonPropertyName("not")]
        public QueryFilterModel? Not { get; set; }

        [MinItems(2)]
        [JsonPropertyName("or")]
        public List<QueryFilterModel>? Or { get; set; }

        [JsonPropertyName("tag")]
        public QueryComparisonExpressionModel? Tag { get; set; }
    }
}
