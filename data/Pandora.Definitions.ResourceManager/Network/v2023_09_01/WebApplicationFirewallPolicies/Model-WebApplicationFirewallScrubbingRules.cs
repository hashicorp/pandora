using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.WebApplicationFirewallPolicies;


internal class WebApplicationFirewallScrubbingRulesModel
{
    [JsonPropertyName("matchVariable")]
    [Required]
    public ScrubbingRuleEntryMatchVariableConstant MatchVariable { get; set; }

    [JsonPropertyName("selector")]
    public string? Selector { get; set; }

    [JsonPropertyName("selectorMatchOperator")]
    [Required]
    public ScrubbingRuleEntryMatchOperatorConstant SelectorMatchOperator { get; set; }

    [JsonPropertyName("state")]
    public ScrubbingRuleEntryStateConstant? State { get; set; }
}
