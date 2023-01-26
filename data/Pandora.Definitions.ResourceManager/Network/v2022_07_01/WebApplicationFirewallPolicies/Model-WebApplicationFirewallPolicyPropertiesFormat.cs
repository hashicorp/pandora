using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.WebApplicationFirewallPolicies;


internal class WebApplicationFirewallPolicyPropertiesFormatModel
{
    [JsonPropertyName("applicationGateways")]
    public List<ApplicationGatewayModel>? ApplicationGateways { get; set; }

    [JsonPropertyName("customRules")]
    public List<WebApplicationFirewallCustomRuleModel>? CustomRules { get; set; }

    [JsonPropertyName("httpListeners")]
    public List<SubResourceModel>? HTTPListeners { get; set; }

    [JsonPropertyName("managedRules")]
    [Required]
    public ManagedRulesDefinitionModel ManagedRules { get; set; }

    [JsonPropertyName("pathBasedRules")]
    public List<SubResourceModel>? PathBasedRules { get; set; }

    [JsonPropertyName("policySettings")]
    public PolicySettingsModel? PolicySettings { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("resourceState")]
    public WebApplicationFirewallPolicyResourceStateConstant? ResourceState { get; set; }
}
