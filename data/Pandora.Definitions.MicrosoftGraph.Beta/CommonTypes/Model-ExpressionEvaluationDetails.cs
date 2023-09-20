// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ExpressionEvaluationDetailsModel
{
    [JsonPropertyName("expression")]
    public string? Expression { get; set; }

    [JsonPropertyName("expressionEvaluationDetails")]
    public List<ExpressionEvaluationDetailsModel>? ExpressionEvaluationDetails { get; set; }

    [JsonPropertyName("expressionResult")]
    public bool? ExpressionResult { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("propertyToEvaluate")]
    public PropertyToEvaluateModel? PropertyToEvaluate { get; set; }
}
