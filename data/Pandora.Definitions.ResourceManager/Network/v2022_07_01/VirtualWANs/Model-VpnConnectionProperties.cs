using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.VirtualWANs;


internal class VpnConnectionPropertiesModel
{
    [JsonPropertyName("connectionBandwidth")]
    public int? ConnectionBandwidth { get; set; }

    [JsonPropertyName("connectionStatus")]
    public VpnConnectionStatusConstant? ConnectionStatus { get; set; }

    [JsonPropertyName("dpdTimeoutSeconds")]
    public int? DpdTimeoutSeconds { get; set; }

    [JsonPropertyName("egressBytesTransferred")]
    public int? EgressBytesTransferred { get; set; }

    [JsonPropertyName("enableBgp")]
    public bool? EnableBgp { get; set; }

    [JsonPropertyName("enableInternetSecurity")]
    public bool? EnableInternetSecurity { get; set; }

    [JsonPropertyName("enableRateLimiting")]
    public bool? EnableRateLimiting { get; set; }

    [JsonPropertyName("ipsecPolicies")]
    public List<IPsecPolicyModel>? IPsecPolicies { get; set; }

    [JsonPropertyName("ingressBytesTransferred")]
    public int? IngressBytesTransferred { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("remoteVpnSite")]
    public SubResourceModel? RemoteVpnSite { get; set; }

    [JsonPropertyName("routingConfiguration")]
    public RoutingConfigurationModel? RoutingConfiguration { get; set; }

    [JsonPropertyName("routingWeight")]
    public int? RoutingWeight { get; set; }

    [JsonPropertyName("sharedKey")]
    public string? SharedKey { get; set; }

    [JsonPropertyName("trafficSelectorPolicies")]
    public List<TrafficSelectorPolicyModel>? TrafficSelectorPolicies { get; set; }

    [JsonPropertyName("useLocalAzureIpAddress")]
    public bool? UseLocalAzureIPAddress { get; set; }

    [JsonPropertyName("usePolicyBasedTrafficSelectors")]
    public bool? UsePolicyBasedTrafficSelectors { get; set; }

    [JsonPropertyName("vpnConnectionProtocolType")]
    public VirtualNetworkGatewayConnectionProtocolConstant? VpnConnectionProtocolType { get; set; }

    [JsonPropertyName("vpnLinkConnections")]
    public List<VpnSiteLinkConnectionModel>? VpnLinkConnections { get; set; }
}
