using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_04_01.WebApplicationFirewallPolicies;


internal class WebApplicationFirewallPolicyPropertiesModel
{
    [JsonPropertyName("customRules")]
    public CustomRuleListModel? CustomRules { get; set; }

    [JsonPropertyName("frontendEndpointLinks")]
    public List<FrontendEndpointLinkModel>? FrontendEndpointLinks { get; set; }

    [JsonPropertyName("managedRules")]
    public ManagedRuleSetListModel? ManagedRules { get; set; }

    [JsonPropertyName("policySettings")]
    public PolicySettingsModel? PolicySettings { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("resourceState")]
    public PolicyResourceStateConstant? ResourceState { get; set; }

    [JsonPropertyName("routingRuleLinks")]
    public List<RoutingRuleLinkModel>? RoutingRuleLinks { get; set; }
}
