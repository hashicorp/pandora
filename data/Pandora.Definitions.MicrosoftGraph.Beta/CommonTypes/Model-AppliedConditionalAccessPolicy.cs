// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AppliedConditionalAccessPolicyModel
{
    [JsonPropertyName("authenticationStrength")]
    public AuthenticationStrengthModel? AuthenticationStrength { get; set; }

    [JsonPropertyName("conditionsNotSatisfied")]
    public AppliedConditionalAccessPolicyConditionsNotSatisfiedConstant? ConditionsNotSatisfied { get; set; }

    [JsonPropertyName("conditionsSatisfied")]
    public AppliedConditionalAccessPolicyConditionsSatisfiedConstant? ConditionsSatisfied { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("enforcedGrantControls")]
    public List<string>? EnforcedGrantControls { get; set; }

    [JsonPropertyName("enforcedSessionControls")]
    public List<string>? EnforcedSessionControls { get; set; }

    [JsonPropertyName("excludeRulesSatisfied")]
    public List<ConditionalAccessRuleSatisfiedModel>? ExcludeRulesSatisfied { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("includeRulesSatisfied")]
    public List<ConditionalAccessRuleSatisfiedModel>? IncludeRulesSatisfied { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("result")]
    public AppliedConditionalAccessPolicyResultConstant? Result { get; set; }

    [JsonPropertyName("sessionControlsNotSatisfied")]
    public List<string>? SessionControlsNotSatisfied { get; set; }
}
