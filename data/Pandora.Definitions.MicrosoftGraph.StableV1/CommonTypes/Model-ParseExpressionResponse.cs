// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class ParseExpressionResponseModel
{
    [JsonPropertyName("error")]
    public PublicErrorModel? Error { get; set; }

    [JsonPropertyName("evaluationResult")]
    public List<string>? EvaluationResult { get; set; }

    [JsonPropertyName("evaluationSucceeded")]
    public bool? EvaluationSucceeded { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("parsedExpression")]
    public AttributeMappingSourceModel? ParsedExpression { get; set; }

    [JsonPropertyName("parsingSucceeded")]
    public bool? ParsingSucceeded { get; set; }
}
