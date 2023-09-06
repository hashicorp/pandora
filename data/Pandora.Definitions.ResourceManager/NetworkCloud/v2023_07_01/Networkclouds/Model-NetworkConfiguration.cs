using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;


internal class NetworkConfigurationModel
{
    [JsonPropertyName("attachedNetworkConfiguration")]
    public AttachedNetworkConfigurationModel? AttachedNetworkConfiguration { get; set; }

    [JsonPropertyName("bgpServiceLoadBalancerConfiguration")]
    public BgpServiceLoadBalancerConfigurationModel? BgpServiceLoadBalancerConfiguration { get; set; }

    [JsonPropertyName("cloudServicesNetworkId")]
    [Required]
    public string CloudServicesNetworkId { get; set; }

    [JsonPropertyName("cniNetworkId")]
    [Required]
    public string CniNetworkId { get; set; }

    [JsonPropertyName("dnsServiceIp")]
    public string? DnsServiceIP { get; set; }

    [JsonPropertyName("podCidrs")]
    public List<string>? PodCidrs { get; set; }

    [JsonPropertyName("serviceCidrs")]
    public List<string>? ServiceCidrs { get; set; }
}
