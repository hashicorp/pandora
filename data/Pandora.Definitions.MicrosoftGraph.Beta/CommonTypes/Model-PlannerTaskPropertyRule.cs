// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class PlannerTaskPropertyRuleModel
{
    [JsonPropertyName("appliedCategories")]
    public PlannerFieldRulesModel? AppliedCategories { get; set; }

    [JsonPropertyName("assignments")]
    public PlannerFieldRulesModel? Assignments { get; set; }

    [JsonPropertyName("checkLists")]
    public PlannerFieldRulesModel? CheckLists { get; set; }

    [JsonPropertyName("completionRequirements")]
    public List<string>? CompletionRequirements { get; set; }

    [JsonPropertyName("delete")]
    public List<string>? Delete { get; set; }

    [JsonPropertyName("dueDate")]
    public List<string>? DueDate { get; set; }

    [JsonPropertyName("move")]
    public List<string>? Move { get; set; }

    [JsonPropertyName("notes")]
    public List<string>? Notes { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("order")]
    public List<string>? Order { get; set; }

    [JsonPropertyName("percentComplete")]
    public List<string>? PercentComplete { get; set; }

    [JsonPropertyName("previewType")]
    public List<string>? PreviewType { get; set; }

    [JsonPropertyName("priority")]
    public List<string>? Priority { get; set; }

    [JsonPropertyName("references")]
    public PlannerFieldRulesModel? References { get; set; }

    [JsonPropertyName("ruleKind")]
    public PlannerRuleKindConstant? RuleKind { get; set; }

    [JsonPropertyName("startDate")]
    public List<string>? StartDate { get; set; }

    [JsonPropertyName("title")]
    public List<string>? Title { get; set; }
}
