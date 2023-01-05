using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2022_11_01.ManagedClusters;


internal class ContainerServiceNetworkProfileModel
{
    [JsonPropertyName("dnsServiceIP")]
    public string? DnsServiceIP { get; set; }

    [JsonPropertyName("dockerBridgeCidr")]
    public string? DockerBridgeCidr { get; set; }

    [JsonPropertyName("ipFamilies")]
    public List<IPFamilyConstant>? IPFamilies { get; set; }

    [JsonPropertyName("loadBalancerProfile")]
    public ManagedClusterLoadBalancerProfileModel? LoadBalancerProfile { get; set; }

    [JsonPropertyName("loadBalancerSku")]
    public LoadBalancerSkuConstant? LoadBalancerSku { get; set; }

    [JsonPropertyName("natGatewayProfile")]
    public ManagedClusterNATGatewayProfileModel? NatGatewayProfile { get; set; }

    [JsonPropertyName("networkMode")]
    public NetworkModeConstant? NetworkMode { get; set; }

    [JsonPropertyName("networkPlugin")]
    public NetworkPluginConstant? NetworkPlugin { get; set; }

    [JsonPropertyName("networkPolicy")]
    public NetworkPolicyConstant? NetworkPolicy { get; set; }

    [JsonPropertyName("outboundType")]
    public OutboundTypeConstant? OutboundType { get; set; }

    [JsonPropertyName("podCidr")]
    public string? PodCidr { get; set; }

    [JsonPropertyName("podCidrs")]
    public List<string>? PodCidrs { get; set; }

    [JsonPropertyName("serviceCidr")]
    public string? ServiceCidr { get; set; }

    [JsonPropertyName("serviceCidrs")]
    public List<string>? ServiceCidrs { get; set; }
}
