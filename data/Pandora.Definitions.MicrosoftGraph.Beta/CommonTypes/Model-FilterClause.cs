// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class FilterClauseModel
{
    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("operatorName")]
    public string? OperatorName { get; set; }

    [JsonPropertyName("sourceOperandName")]
    public string? SourceOperandName { get; set; }

    [JsonPropertyName("targetOperand")]
    public FilterOperandModel? TargetOperand { get; set; }
}
