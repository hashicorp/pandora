using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.LoadBalancers;


internal class LoadBalancerPropertiesFormatModel
{
    [JsonPropertyName("backendAddressPools")]
    public List<BackendAddressPoolModel>? BackendAddressPools { get; set; }

    [JsonPropertyName("frontendIPConfigurations")]
    public List<FrontendIPConfigurationModel>? FrontendIPConfigurations { get; set; }

    [JsonPropertyName("inboundNatPools")]
    public List<InboundNatPoolModel>? InboundNatPools { get; set; }

    [JsonPropertyName("inboundNatRules")]
    public List<InboundNatRuleModel>? InboundNatRules { get; set; }

    [JsonPropertyName("loadBalancingRules")]
    public List<LoadBalancingRuleModel>? LoadBalancingRules { get; set; }

    [JsonPropertyName("outboundRules")]
    public List<OutboundRuleModel>? OutboundRules { get; set; }

    [JsonPropertyName("probes")]
    public List<ProbeModel>? Probes { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("resourceGuid")]
    public string? ResourceGuid { get; set; }
}
