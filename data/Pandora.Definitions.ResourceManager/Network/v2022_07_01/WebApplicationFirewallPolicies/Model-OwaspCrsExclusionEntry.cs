using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.WebApplicationFirewallPolicies;


internal class OwaspCrsExclusionEntryModel
{
    [JsonPropertyName("exclusionManagedRuleSets")]
    public List<ExclusionManagedRuleSetModel>? ExclusionManagedRuleSets { get; set; }

    [JsonPropertyName("matchVariable")]
    [Required]
    public OwaspCrsExclusionEntryMatchVariableConstant MatchVariable { get; set; }

    [JsonPropertyName("selector")]
    [Required]
    public string Selector { get; set; }

    [JsonPropertyName("selectorMatchOperator")]
    [Required]
    public OwaspCrsExclusionEntrySelectorMatchOperatorConstant SelectorMatchOperator { get; set; }
}
