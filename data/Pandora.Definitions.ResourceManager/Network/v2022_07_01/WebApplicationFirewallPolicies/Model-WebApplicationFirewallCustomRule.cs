using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.WebApplicationFirewallPolicies;


internal class WebApplicationFirewallCustomRuleModel
{
    [JsonPropertyName("action")]
    [Required]
    public WebApplicationFirewallActionConstant Action { get; set; }

    [JsonPropertyName("etag")]
    public string? Etag { get; set; }

    [JsonPropertyName("matchConditions")]
    [Required]
    public List<MatchConditionModel> MatchConditions { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("priority")]
    [Required]
    public int Priority { get; set; }

    [JsonPropertyName("ruleType")]
    [Required]
    public WebApplicationFirewallRuleTypeConstant RuleType { get; set; }
}
