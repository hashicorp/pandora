// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class NetworkaccessM365ForwardingRuleModel
{
    [JsonPropertyName("action")]
    public NetworkaccessM365ForwardingRuleActionConstant? Action { get; set; }

    [JsonPropertyName("category")]
    public NetworkaccessM365ForwardingRuleCategoryConstant? Category { get; set; }

    [JsonPropertyName("destinations")]
    public List<NetworkaccessRuleDestinationModel>? Destinations { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("ports")]
    public List<string>? Ports { get; set; }

    [JsonPropertyName("protocol")]
    public NetworkaccessM365ForwardingRuleProtocolConstant? Protocol { get; set; }

    [JsonPropertyName("ruleType")]
    public NetworkaccessM365ForwardingRuleRuleTypeConstant? RuleType { get; set; }
}
