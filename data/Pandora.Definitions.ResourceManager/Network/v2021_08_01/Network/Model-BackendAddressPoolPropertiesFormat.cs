using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.Network;


internal class BackendAddressPoolPropertiesFormatModel
{
    [JsonPropertyName("backendIPConfigurations")]
    public List<NetworkInterfaceIPConfigurationModel>? BackendIPConfigurations { get; set; }

    [JsonPropertyName("drainPeriodInSeconds")]
    public int? DrainPeriodInSeconds { get; set; }

    [JsonPropertyName("inboundNatRules")]
    public List<SubResourceModel>? InboundNatRules { get; set; }

    [JsonPropertyName("loadBalancerBackendAddresses")]
    public List<LoadBalancerBackendAddressModel>? LoadBalancerBackendAddresses { get; set; }

    [JsonPropertyName("loadBalancingRules")]
    public List<SubResourceModel>? LoadBalancingRules { get; set; }

    [JsonPropertyName("location")]
    public CustomTypes.Location? Location { get; set; }

    [JsonPropertyName("outboundRule")]
    public SubResourceModel? OutboundRule { get; set; }

    [JsonPropertyName("outboundRules")]
    public List<SubResourceModel>? OutboundRules { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("tunnelInterfaces")]
    public List<GatewayLoadBalancerTunnelInterfaceModel>? TunnelInterfaces { get; set; }
}
