using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.VirtualWANs;


internal class VirtualHubPropertiesModel
{
    [JsonPropertyName("addressPrefix")]
    public string? AddressPrefix { get; set; }

    [JsonPropertyName("allowBranchToBranchTraffic")]
    public bool? AllowBranchToBranchTraffic { get; set; }

    [JsonPropertyName("azureFirewall")]
    public SubResourceModel? AzureFirewall { get; set; }

    [JsonPropertyName("bgpConnections")]
    public List<SubResourceModel>? BgpConnections { get; set; }

    [JsonPropertyName("expressRouteGateway")]
    public SubResourceModel? ExpressRouteGateway { get; set; }

    [JsonPropertyName("hubRoutingPreference")]
    public HubRoutingPreferenceConstant? HubRoutingPreference { get; set; }

    [JsonPropertyName("ipConfigurations")]
    public List<SubResourceModel>? IPConfigurations { get; set; }

    [JsonPropertyName("p2SVpnGateway")]
    public SubResourceModel? P2SVpnGateway { get; set; }

    [JsonPropertyName("preferredRoutingGateway")]
    public PreferredRoutingGatewayConstant? PreferredRoutingGateway { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("routeTable")]
    public VirtualHubRouteTableModel? RouteTable { get; set; }

    [JsonPropertyName("routingState")]
    public RoutingStateConstant? RoutingState { get; set; }

    [JsonPropertyName("securityPartnerProvider")]
    public SubResourceModel? SecurityPartnerProvider { get; set; }

    [JsonPropertyName("securityProviderName")]
    public string? SecurityProviderName { get; set; }

    [JsonPropertyName("sku")]
    public string? Sku { get; set; }

    [JsonPropertyName("virtualHubRouteTableV2s")]
    public List<VirtualHubRouteTableV2Model>? VirtualHubRouteTableV2s { get; set; }

    [JsonPropertyName("virtualRouterAsn")]
    public int? VirtualRouterAsn { get; set; }

    [JsonPropertyName("virtualRouterIps")]
    public List<string>? VirtualRouterIPs { get; set; }

    [JsonPropertyName("virtualWan")]
    public SubResourceModel? VirtualWan { get; set; }

    [JsonPropertyName("vpnGateway")]
    public SubResourceModel? VpnGateway { get; set; }
}
