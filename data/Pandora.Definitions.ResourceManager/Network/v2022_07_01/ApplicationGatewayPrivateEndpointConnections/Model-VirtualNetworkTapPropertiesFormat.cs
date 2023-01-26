using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.ApplicationGatewayPrivateEndpointConnections;


internal class VirtualNetworkTapPropertiesFormatModel
{
    [JsonPropertyName("destinationLoadBalancerFrontEndIPConfiguration")]
    public FrontendIPConfigurationModel? DestinationLoadBalancerFrontEndIPConfiguration { get; set; }

    [JsonPropertyName("destinationNetworkInterfaceIPConfiguration")]
    public NetworkInterfaceIPConfigurationModel? DestinationNetworkInterfaceIPConfiguration { get; set; }

    [JsonPropertyName("destinationPort")]
    public int? DestinationPort { get; set; }

    [JsonPropertyName("networkInterfaceTapConfigurations")]
    public List<NetworkInterfaceTapConfigurationModel>? NetworkInterfaceTapConfigurations { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("resourceGuid")]
    public string? ResourceGuid { get; set; }
}
