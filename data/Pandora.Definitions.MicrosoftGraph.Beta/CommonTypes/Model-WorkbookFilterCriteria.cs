// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WorkbookFilterCriteriaModel
{
    [JsonPropertyName("color")]
    public string? Color { get; set; }

    [JsonPropertyName("criterion1")]
    public string? Criterion1 { get; set; }

    [JsonPropertyName("criterion2")]
    public string? Criterion2 { get; set; }

    [JsonPropertyName("dynamicCriteria")]
    public string? DynamicCriteria { get; set; }

    [JsonPropertyName("filterOn")]
    public string? FilterOn { get; set; }

    [JsonPropertyName("icon")]
    public WorkbookIconModel? Icon { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("operator")]
    public string? Operator { get; set; }

    [JsonPropertyName("values")]
    public JsonModel? Values { get; set; }
}
