using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.VirtualNetworkTap;


internal class PrivateLinkServicePropertiesModel
{
    [JsonPropertyName("alias")]
    public string? Alias { get; set; }

    [JsonPropertyName("autoApproval")]
    public ResourceSetModel? AutoApproval { get; set; }

    [JsonPropertyName("enableProxyProtocol")]
    public bool? EnableProxyProtocol { get; set; }

    [JsonPropertyName("fqdns")]
    public List<string>? Fqdns { get; set; }

    [JsonPropertyName("ipConfigurations")]
    public List<PrivateLinkServiceIPConfigurationModel>? IPConfigurations { get; set; }

    [JsonPropertyName("loadBalancerFrontendIpConfigurations")]
    public List<FrontendIPConfigurationModel>? LoadBalancerFrontendIPConfigurations { get; set; }

    [JsonPropertyName("networkInterfaces")]
    public List<NetworkInterfaceModel>? NetworkInterfaces { get; set; }

    [JsonPropertyName("privateEndpointConnections")]
    public List<PrivateEndpointConnectionModel>? PrivateEndpointConnections { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("visibility")]
    public ResourceSetModel? Visibility { get; set; }
}
