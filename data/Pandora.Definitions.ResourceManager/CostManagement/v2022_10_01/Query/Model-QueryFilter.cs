using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2022_10_01.Query;


internal class QueryFilterModel
{
    [MinItems(2)]
    [JsonPropertyName("and")]
    public List<QueryFilterModel>? And { get; set; }

    [JsonPropertyName("dimensions")]
    public QueryComparisonExpressionModel? Dimensions { get; set; }

    [MinItems(2)]
    [JsonPropertyName("or")]
    public List<QueryFilterModel>? Or { get; set; }

    [JsonPropertyName("tags")]
    public QueryComparisonExpressionModel? Tags { get; set; }
}
