using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.LoadBalancers;


internal class LoadBalancingRulePropertiesFormatModel
{
    [JsonPropertyName("backendAddressPool")]
    public SubResourceModel? BackendAddressPool { get; set; }

    [JsonPropertyName("backendAddressPools")]
    public List<SubResourceModel>? BackendAddressPools { get; set; }

    [JsonPropertyName("backendPort")]
    public int? BackendPort { get; set; }

    [JsonPropertyName("disableOutboundSnat")]
    public bool? DisableOutboundSnat { get; set; }

    [JsonPropertyName("enableFloatingIP")]
    public bool? EnableFloatingIP { get; set; }

    [JsonPropertyName("enableTcpReset")]
    public bool? EnableTcpReset { get; set; }

    [JsonPropertyName("frontendIPConfiguration")]
    public SubResourceModel? FrontendIPConfiguration { get; set; }

    [JsonPropertyName("frontendPort")]
    [Required]
    public int FrontendPort { get; set; }

    [JsonPropertyName("idleTimeoutInMinutes")]
    public int? IdleTimeoutInMinutes { get; set; }

    [JsonPropertyName("loadDistribution")]
    public LoadDistributionConstant? LoadDistribution { get; set; }

    [JsonPropertyName("probe")]
    public SubResourceModel? Probe { get; set; }

    [JsonPropertyName("protocol")]
    [Required]
    public TransportProtocolConstant Protocol { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }
}
