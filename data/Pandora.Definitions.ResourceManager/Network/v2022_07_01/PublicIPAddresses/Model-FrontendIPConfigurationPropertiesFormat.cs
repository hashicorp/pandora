using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.PublicIPAddresses;


internal class FrontendIPConfigurationPropertiesFormatModel
{
    [JsonPropertyName("gatewayLoadBalancer")]
    public SubResourceModel? GatewayLoadBalancer { get; set; }

    [JsonPropertyName("inboundNatPools")]
    public List<SubResourceModel>? InboundNatPools { get; set; }

    [JsonPropertyName("inboundNatRules")]
    public List<SubResourceModel>? InboundNatRules { get; set; }

    [JsonPropertyName("loadBalancingRules")]
    public List<SubResourceModel>? LoadBalancingRules { get; set; }

    [JsonPropertyName("outboundRules")]
    public List<SubResourceModel>? OutboundRules { get; set; }

    [JsonPropertyName("privateIPAddress")]
    public string? PrivateIPAddress { get; set; }

    [JsonPropertyName("privateIPAddressVersion")]
    public IPVersionConstant? PrivateIPAddressVersion { get; set; }

    [JsonPropertyName("privateIPAllocationMethod")]
    public IPAllocationMethodConstant? PrivateIPAllocationMethod { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("publicIPAddress")]
    public PublicIPAddressModel? PublicIPAddress { get; set; }

    [JsonPropertyName("publicIPPrefix")]
    public SubResourceModel? PublicIPPrefix { get; set; }

    [JsonPropertyName("subnet")]
    public SubnetModel? Subnet { get; set; }
}
