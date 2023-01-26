using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.VirtualNetworkTap;


internal class NetworkInterfaceIPConfigurationPropertiesFormatModel
{
    [JsonPropertyName("applicationGatewayBackendAddressPools")]
    public List<ApplicationGatewayBackendAddressPoolModel>? ApplicationGatewayBackendAddressPools { get; set; }

    [JsonPropertyName("applicationSecurityGroups")]
    public List<ApplicationSecurityGroupModel>? ApplicationSecurityGroups { get; set; }

    [JsonPropertyName("gatewayLoadBalancer")]
    public SubResourceModel? GatewayLoadBalancer { get; set; }

    [JsonPropertyName("loadBalancerBackendAddressPools")]
    public List<BackendAddressPoolModel>? LoadBalancerBackendAddressPools { get; set; }

    [JsonPropertyName("loadBalancerInboundNatRules")]
    public List<InboundNatRuleModel>? LoadBalancerInboundNatRules { get; set; }

    [JsonPropertyName("primary")]
    public bool? Primary { get; set; }

    [JsonPropertyName("privateIPAddress")]
    public string? PrivateIPAddress { get; set; }

    [JsonPropertyName("privateIPAddressVersion")]
    public IPVersionConstant? PrivateIPAddressVersion { get; set; }

    [JsonPropertyName("privateIPAllocationMethod")]
    public IPAllocationMethodConstant? PrivateIPAllocationMethod { get; set; }

    [JsonPropertyName("privateLinkConnectionProperties")]
    public NetworkInterfaceIPConfigurationPrivateLinkConnectionPropertiesModel? PrivateLinkConnectionProperties { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("publicIPAddress")]
    public PublicIPAddressModel? PublicIPAddress { get; set; }

    [JsonPropertyName("subnet")]
    public SubnetModel? Subnet { get; set; }

    [JsonPropertyName("virtualNetworkTaps")]
    public List<VirtualNetworkTapModel>? VirtualNetworkTaps { get; set; }
}
