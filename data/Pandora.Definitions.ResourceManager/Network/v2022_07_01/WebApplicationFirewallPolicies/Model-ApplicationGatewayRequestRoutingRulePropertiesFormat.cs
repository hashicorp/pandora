using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.WebApplicationFirewallPolicies;


internal class ApplicationGatewayRequestRoutingRulePropertiesFormatModel
{
    [JsonPropertyName("backendAddressPool")]
    public SubResourceModel? BackendAddressPool { get; set; }

    [JsonPropertyName("backendHttpSettings")]
    public SubResourceModel? BackendHTTPSettings { get; set; }

    [JsonPropertyName("httpListener")]
    public SubResourceModel? HTTPListener { get; set; }

    [JsonPropertyName("loadDistributionPolicy")]
    public SubResourceModel? LoadDistributionPolicy { get; set; }

    [JsonPropertyName("priority")]
    public int? Priority { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("redirectConfiguration")]
    public SubResourceModel? RedirectConfiguration { get; set; }

    [JsonPropertyName("rewriteRuleSet")]
    public SubResourceModel? RewriteRuleSet { get; set; }

    [JsonPropertyName("ruleType")]
    public ApplicationGatewayRequestRoutingRuleTypeConstant? RuleType { get; set; }

    [JsonPropertyName("urlPathMap")]
    public SubResourceModel? UrlPathMap { get; set; }
}
