using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.VirtualNetworkGatewayConnections;


internal class VirtualNetworkGatewayPropertiesFormatModel
{
    [JsonPropertyName("activeActive")]
    public bool? ActiveActive { get; set; }

    [JsonPropertyName("allowRemoteVnetTraffic")]
    public bool? AllowRemoteVnetTraffic { get; set; }

    [JsonPropertyName("allowVirtualWanTraffic")]
    public bool? AllowVirtualWanTraffic { get; set; }

    [JsonPropertyName("bgpSettings")]
    public BgpSettingsModel? BgpSettings { get; set; }

    [JsonPropertyName("customRoutes")]
    public AddressSpaceModel? CustomRoutes { get; set; }

    [JsonPropertyName("disableIPSecReplayProtection")]
    public bool? DisableIPSecReplayProtection { get; set; }

    [JsonPropertyName("enableBgp")]
    public bool? EnableBgp { get; set; }

    [JsonPropertyName("enableBgpRouteTranslationForNat")]
    public bool? EnableBgpRouteTranslationForNat { get; set; }

    [JsonPropertyName("enableDnsForwarding")]
    public bool? EnableDnsForwarding { get; set; }

    [JsonPropertyName("enablePrivateIpAddress")]
    public bool? EnablePrivateIPAddress { get; set; }

    [JsonPropertyName("gatewayDefaultSite")]
    public SubResourceModel? GatewayDefaultSite { get; set; }

    [JsonPropertyName("gatewayType")]
    public VirtualNetworkGatewayTypeConstant? GatewayType { get; set; }

    [JsonPropertyName("ipConfigurations")]
    public List<VirtualNetworkGatewayIPConfigurationModel>? IPConfigurations { get; set; }

    [JsonPropertyName("inboundDnsForwardingEndpoint")]
    public string? InboundDnsForwardingEndpoint { get; set; }

    [JsonPropertyName("natRules")]
    public List<VirtualNetworkGatewayNatRuleModel>? NatRules { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("resourceGuid")]
    public string? ResourceGuid { get; set; }

    [JsonPropertyName("sku")]
    public VirtualNetworkGatewaySkuModel? Sku { get; set; }

    [JsonPropertyName("vNetExtendedLocationResourceId")]
    public string? VNetExtendedLocationResourceId { get; set; }

    [JsonPropertyName("virtualNetworkGatewayPolicyGroups")]
    public List<VirtualNetworkGatewayPolicyGroupModel>? VirtualNetworkGatewayPolicyGroups { get; set; }

    [JsonPropertyName("vpnClientConfiguration")]
    public VpnClientConfigurationModel? VpnClientConfiguration { get; set; }

    [JsonPropertyName("vpnGatewayGeneration")]
    public VpnGatewayGenerationConstant? VpnGatewayGeneration { get; set; }

    [JsonPropertyName("vpnType")]
    public VpnTypeConstant? VpnType { get; set; }
}
