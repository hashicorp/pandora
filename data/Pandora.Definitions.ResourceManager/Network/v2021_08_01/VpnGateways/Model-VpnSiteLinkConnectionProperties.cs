using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.VpnGateways;


internal class VpnSiteLinkConnectionPropertiesModel
{
    [JsonPropertyName("connectionBandwidth")]
    public int? ConnectionBandwidth { get; set; }

    [JsonPropertyName("connectionStatus")]
    public VpnConnectionStatusConstant? ConnectionStatus { get; set; }

    [JsonPropertyName("egressBytesTransferred")]
    public int? EgressBytesTransferred { get; set; }

    [JsonPropertyName("egressNatRules")]
    public List<SubResourceModel>? EgressNatRules { get; set; }

    [JsonPropertyName("enableBgp")]
    public bool? EnableBgp { get; set; }

    [JsonPropertyName("enableRateLimiting")]
    public bool? EnableRateLimiting { get; set; }

    [JsonPropertyName("ipsecPolicies")]
    public List<IPsecPolicyModel>? IPsecPolicies { get; set; }

    [JsonPropertyName("ingressBytesTransferred")]
    public int? IngressBytesTransferred { get; set; }

    [JsonPropertyName("ingressNatRules")]
    public List<SubResourceModel>? IngressNatRules { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("routingWeight")]
    public int? RoutingWeight { get; set; }

    [JsonPropertyName("sharedKey")]
    public string? SharedKey { get; set; }

    [JsonPropertyName("useLocalAzureIpAddress")]
    public bool? UseLocalAzureIPAddress { get; set; }

    [JsonPropertyName("usePolicyBasedTrafficSelectors")]
    public bool? UsePolicyBasedTrafficSelectors { get; set; }

    [JsonPropertyName("vpnConnectionProtocolType")]
    public VirtualNetworkGatewayConnectionProtocolConstant? VpnConnectionProtocolType { get; set; }

    [JsonPropertyName("vpnGatewayCustomBgpAddresses")]
    public List<GatewayCustomBgpIPAddressIPConfigurationModel>? VpnGatewayCustomBgpAddresses { get; set; }

    [JsonPropertyName("vpnLinkConnectionMode")]
    public VpnLinkConnectionModeConstant? VpnLinkConnectionMode { get; set; }

    [JsonPropertyName("vpnSiteLink")]
    public SubResourceModel? VpnSiteLink { get; set; }
}
