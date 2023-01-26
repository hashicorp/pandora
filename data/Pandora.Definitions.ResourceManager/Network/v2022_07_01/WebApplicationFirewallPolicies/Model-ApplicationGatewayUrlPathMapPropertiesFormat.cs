using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.WebApplicationFirewallPolicies;


internal class ApplicationGatewayUrlPathMapPropertiesFormatModel
{
    [JsonPropertyName("defaultBackendAddressPool")]
    public SubResourceModel? DefaultBackendAddressPool { get; set; }

    [JsonPropertyName("defaultBackendHttpSettings")]
    public SubResourceModel? DefaultBackendHTTPSettings { get; set; }

    [JsonPropertyName("defaultLoadDistributionPolicy")]
    public SubResourceModel? DefaultLoadDistributionPolicy { get; set; }

    [JsonPropertyName("defaultRedirectConfiguration")]
    public SubResourceModel? DefaultRedirectConfiguration { get; set; }

    [JsonPropertyName("defaultRewriteRuleSet")]
    public SubResourceModel? DefaultRewriteRuleSet { get; set; }

    [JsonPropertyName("pathRules")]
    public List<ApplicationGatewayPathRuleModel>? PathRules { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }
}
