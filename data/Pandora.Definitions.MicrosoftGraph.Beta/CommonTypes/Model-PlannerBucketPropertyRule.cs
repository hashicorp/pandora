// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class PlannerBucketPropertyRuleModel
{
    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("order")]
    public List<string>? Order { get; set; }

    [JsonPropertyName("ruleKind")]
    public PlannerRuleKindConstant? RuleKind { get; set; }

    [JsonPropertyName("title")]
    public List<string>? Title { get; set; }
}
