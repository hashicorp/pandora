// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AwsStatementModel
{
    [JsonPropertyName("actions")]
    public List<string>? Actions { get; set; }

    [JsonPropertyName("condition")]
    public AwsConditionModel? Condition { get; set; }

    [JsonPropertyName("effect")]
    public AwsStatementEffectConstant? Effect { get; set; }

    [JsonPropertyName("notActions")]
    public List<string>? NotActions { get; set; }

    [JsonPropertyName("notResources")]
    public List<string>? NotResources { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("resources")]
    public List<string>? Resources { get; set; }

    [JsonPropertyName("statementId")]
    public string? StatementId { get; set; }
}
