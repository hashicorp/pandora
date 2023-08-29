using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ResourceGraph.v2022_10_01.Resources;


internal class QueryResponseModel
{
    [JsonPropertyName("count")]
    [Required]
    public int Count { get; set; }

    [JsonPropertyName("data")]
    [Required]
    public object Data { get; set; }

    [JsonPropertyName("facets")]
    public List<FacetModel>? Facets { get; set; }

    [JsonPropertyName("resultTruncated")]
    [Required]
    public ResultTruncatedConstant ResultTruncated { get; set; }

    [JsonPropertyName("$skipToken")]
    public string? SkipToken { get; set; }

    [JsonPropertyName("totalRecords")]
    [Required]
    public int TotalRecords { get; set; }
}
