using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.VirtualWANs;


internal class LoadBalancerBackendAddressPropertiesFormatModel
{
    [JsonPropertyName("adminState")]
    public LoadBalancerBackendAddressAdminStateConstant? AdminState { get; set; }

    [JsonPropertyName("ipAddress")]
    public string? IPAddress { get; set; }

    [JsonPropertyName("inboundNatRulesPortMapping")]
    public List<NatRulePortMappingModel>? InboundNatRulesPortMapping { get; set; }

    [JsonPropertyName("loadBalancerFrontendIPConfiguration")]
    public SubResourceModel? LoadBalancerFrontendIPConfiguration { get; set; }

    [JsonPropertyName("networkInterfaceIPConfiguration")]
    public SubResourceModel? NetworkInterfaceIPConfiguration { get; set; }

    [JsonPropertyName("subnet")]
    public SubResourceModel? Subnet { get; set; }

    [JsonPropertyName("virtualNetwork")]
    public SubResourceModel? VirtualNetwork { get; set; }
}
