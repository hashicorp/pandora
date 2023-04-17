using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PolicyInsights.v2023_03_01.CheckPolicyRestrictions;


internal class ExpressionEvaluationDetailsModel
{
    [JsonPropertyName("expression")]
    public string? Expression { get; set; }

    [JsonPropertyName("expressionKind")]
    public string? ExpressionKind { get; set; }

    [JsonPropertyName("expressionValue")]
    public object? ExpressionValue { get; set; }

    [JsonPropertyName("operator")]
    public string? Operator { get; set; }

    [JsonPropertyName("path")]
    public string? Path { get; set; }

    [JsonPropertyName("result")]
    public string? Result { get; set; }

    [JsonPropertyName("targetValue")]
    public object? TargetValue { get; set; }
}
