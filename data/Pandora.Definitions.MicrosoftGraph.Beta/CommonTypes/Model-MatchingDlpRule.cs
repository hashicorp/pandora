// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class MatchingDlpRuleModel
{
    [JsonPropertyName("actions")]
    public List<DlpActionInfoModel>? Actions { get; set; }

    [JsonPropertyName("isMostRestrictive")]
    public bool? IsMostRestrictive { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("policyId")]
    public string? PolicyId { get; set; }

    [JsonPropertyName("policyName")]
    public string? PolicyName { get; set; }

    [JsonPropertyName("priority")]
    public int? Priority { get; set; }

    [JsonPropertyName("ruleId")]
    public string? RuleId { get; set; }

    [JsonPropertyName("ruleMode")]
    public RuleModeConstant? RuleMode { get; set; }

    [JsonPropertyName("ruleName")]
    public string? RuleName { get; set; }
}
