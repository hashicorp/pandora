// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class PlannerPlanPropertyRuleModel
{
    [JsonPropertyName("buckets")]
    public List<string>? Buckets { get; set; }

    [JsonPropertyName("categoryDescriptions")]
    public PlannerFieldRulesModel? CategoryDescriptions { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("ruleKind")]
    public PlannerRuleKindConstant? RuleKind { get; set; }

    [JsonPropertyName("tasks")]
    public List<string>? Tasks { get; set; }

    [JsonPropertyName("title")]
    public PlannerFieldRulesModel? Title { get; set; }
}
