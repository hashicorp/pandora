using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.WebApplicationFirewallPolicies;


internal class ApplicationGatewayPathRulePropertiesFormatModel
{
    [JsonPropertyName("backendAddressPool")]
    public SubResourceModel? BackendAddressPool { get; set; }

    [JsonPropertyName("backendHttpSettings")]
    public SubResourceModel? BackendHttpSettings { get; set; }

    [JsonPropertyName("firewallPolicy")]
    public SubResourceModel? FirewallPolicy { get; set; }

    [JsonPropertyName("loadDistributionPolicy")]
    public SubResourceModel? LoadDistributionPolicy { get; set; }

    [JsonPropertyName("paths")]
    public List<string>? Paths { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("redirectConfiguration")]
    public SubResourceModel? RedirectConfiguration { get; set; }

    [JsonPropertyName("rewriteRuleSet")]
    public SubResourceModel? RewriteRuleSet { get; set; }
}
