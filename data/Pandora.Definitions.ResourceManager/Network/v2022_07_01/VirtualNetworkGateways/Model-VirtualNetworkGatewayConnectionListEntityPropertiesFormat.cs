using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.VirtualNetworkGateways;


internal class VirtualNetworkGatewayConnectionListEntityPropertiesFormatModel
{
    [JsonPropertyName("authorizationKey")]
    public string? AuthorizationKey { get; set; }

    [JsonPropertyName("connectionMode")]
    public VirtualNetworkGatewayConnectionModeConstant? ConnectionMode { get; set; }

    [JsonPropertyName("connectionProtocol")]
    public VirtualNetworkGatewayConnectionProtocolConstant? ConnectionProtocol { get; set; }

    [JsonPropertyName("connectionStatus")]
    public VirtualNetworkGatewayConnectionStatusConstant? ConnectionStatus { get; set; }

    [JsonPropertyName("connectionType")]
    [Required]
    public VirtualNetworkGatewayConnectionTypeConstant ConnectionType { get; set; }

    [JsonPropertyName("egressBytesTransferred")]
    public int? EgressBytesTransferred { get; set; }

    [JsonPropertyName("enableBgp")]
    public bool? EnableBgp { get; set; }

    [JsonPropertyName("enablePrivateLinkFastPath")]
    public bool? EnablePrivateLinkFastPath { get; set; }

    [JsonPropertyName("expressRouteGatewayBypass")]
    public bool? ExpressRouteGatewayBypass { get; set; }

    [JsonPropertyName("gatewayCustomBgpIpAddresses")]
    public List<GatewayCustomBgpIPAddressIPConfigurationModel>? GatewayCustomBgpIPAddresses { get; set; }

    [JsonPropertyName("ipsecPolicies")]
    public List<IPsecPolicyModel>? IPsecPolicies { get; set; }

    [JsonPropertyName("ingressBytesTransferred")]
    public int? IngressBytesTransferred { get; set; }

    [JsonPropertyName("localNetworkGateway2")]
    public VirtualNetworkConnectionGatewayReferenceModel? LocalNetworkGateway2 { get; set; }

    [JsonPropertyName("peer")]
    public SubResourceModel? Peer { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("resourceGuid")]
    public string? ResourceGuid { get; set; }

    [JsonPropertyName("routingWeight")]
    public int? RoutingWeight { get; set; }

    [JsonPropertyName("sharedKey")]
    public string? SharedKey { get; set; }

    [JsonPropertyName("trafficSelectorPolicies")]
    public List<TrafficSelectorPolicyModel>? TrafficSelectorPolicies { get; set; }

    [JsonPropertyName("tunnelConnectionStatus")]
    public List<TunnelConnectionHealthModel>? TunnelConnectionStatus { get; set; }

    [JsonPropertyName("usePolicyBasedTrafficSelectors")]
    public bool? UsePolicyBasedTrafficSelectors { get; set; }

    [JsonPropertyName("virtualNetworkGateway1")]
    [Required]
    public VirtualNetworkConnectionGatewayReferenceModel VirtualNetworkGateway1 { get; set; }

    [JsonPropertyName("virtualNetworkGateway2")]
    public VirtualNetworkConnectionGatewayReferenceModel? VirtualNetworkGateway2 { get; set; }
}
