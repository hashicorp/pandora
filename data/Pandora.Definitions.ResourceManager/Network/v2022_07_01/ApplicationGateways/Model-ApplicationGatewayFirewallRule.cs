using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.ApplicationGateways;


internal class ApplicationGatewayFirewallRuleModel
{
    [JsonPropertyName("action")]
    public ApplicationGatewayWafRuleActionTypesConstant? Action { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("ruleId")]
    [Required]
    public int RuleId { get; set; }

    [JsonPropertyName("ruleIdString")]
    public string? RuleIdString { get; set; }

    [JsonPropertyName("state")]
    public ApplicationGatewayWafRuleStateTypesConstant? State { get; set; }
}
