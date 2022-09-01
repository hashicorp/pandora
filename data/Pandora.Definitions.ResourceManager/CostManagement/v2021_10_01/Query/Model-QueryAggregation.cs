using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.Query;


internal class QueryAggregationModel
{
    [JsonPropertyName("function")]
    [Required]
    public FunctionTypeConstant Function { get; set; }

    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }
}
