using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_04_01.WebApplicationFirewallPolicies;


internal class ManagedRuleOverrideModel
{
    [JsonPropertyName("action")]
    public ActionTypeConstant? Action { get; set; }

    [JsonPropertyName("enabledState")]
    public ManagedRuleEnabledStateConstant? EnabledState { get; set; }

    [JsonPropertyName("exclusions")]
    public List<ManagedRuleExclusionModel>? Exclusions { get; set; }

    [JsonPropertyName("ruleId")]
    [Required]
    public string RuleId { get; set; }
}
