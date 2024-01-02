using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.ExpressRouteCrossConnectionPeerings;


internal class ExpressRouteCrossConnectionPeeringPropertiesModel
{
    [JsonPropertyName("azureASN")]
    public int? AzureASN { get; set; }

    [JsonPropertyName("gatewayManagerEtag")]
    public string? GatewayManagerEtag { get; set; }

    [JsonPropertyName("ipv6PeeringConfig")]
    public IPv6ExpressRouteCircuitPeeringConfigModel? IPv6PeeringConfig { get; set; }

    [JsonPropertyName("lastModifiedBy")]
    public string? LastModifiedBy { get; set; }

    [JsonPropertyName("microsoftPeeringConfig")]
    public ExpressRouteCircuitPeeringConfigModel? MicrosoftPeeringConfig { get; set; }

    [JsonPropertyName("peerASN")]
    public int? PeerASN { get; set; }

    [JsonPropertyName("peeringType")]
    public ExpressRoutePeeringTypeConstant? PeeringType { get; set; }

    [JsonPropertyName("primaryAzurePort")]
    public string? PrimaryAzurePort { get; set; }

    [JsonPropertyName("primaryPeerAddressPrefix")]
    public string? PrimaryPeerAddressPrefix { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("secondaryAzurePort")]
    public string? SecondaryAzurePort { get; set; }

    [JsonPropertyName("secondaryPeerAddressPrefix")]
    public string? SecondaryPeerAddressPrefix { get; set; }

    [JsonPropertyName("sharedKey")]
    public string? SharedKey { get; set; }

    [JsonPropertyName("state")]
    public ExpressRoutePeeringStateConstant? State { get; set; }

    [JsonPropertyName("vlanId")]
    public int? VlanId { get; set; }
}
