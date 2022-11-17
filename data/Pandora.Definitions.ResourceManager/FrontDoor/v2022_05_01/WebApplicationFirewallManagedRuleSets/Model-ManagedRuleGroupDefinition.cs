using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.FrontDoor.v2022_05_01.WebApplicationFirewallManagedRuleSets;


internal class ManagedRuleGroupDefinitionModel
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("ruleGroupName")]
    public string? RuleGroupName { get; set; }

    [JsonPropertyName("rules")]
    public List<ManagedRuleDefinitionModel>? Rules { get; set; }
}
