using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.VirtualNetworks;


internal class VirtualNetworkPeeringPropertiesFormatModel
{
    [JsonPropertyName("allowForwardedTraffic")]
    public bool? AllowForwardedTraffic { get; set; }

    [JsonPropertyName("allowGatewayTransit")]
    public bool? AllowGatewayTransit { get; set; }

    [JsonPropertyName("allowVirtualNetworkAccess")]
    public bool? AllowVirtualNetworkAccess { get; set; }

    [JsonPropertyName("doNotVerifyRemoteGateways")]
    public bool? DoNotVerifyRemoteGateways { get; set; }

    [JsonPropertyName("peeringState")]
    public VirtualNetworkPeeringStateConstant? PeeringState { get; set; }

    [JsonPropertyName("peeringSyncLevel")]
    public VirtualNetworkPeeringLevelConstant? PeeringSyncLevel { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("remoteAddressSpace")]
    public AddressSpaceModel? RemoteAddressSpace { get; set; }

    [JsonPropertyName("remoteBgpCommunities")]
    public VirtualNetworkBgpCommunitiesModel? RemoteBgpCommunities { get; set; }

    [JsonPropertyName("remoteVirtualNetwork")]
    public SubResourceModel? RemoteVirtualNetwork { get; set; }

    [JsonPropertyName("remoteVirtualNetworkAddressSpace")]
    public AddressSpaceModel? RemoteVirtualNetworkAddressSpace { get; set; }

    [JsonPropertyName("remoteVirtualNetworkEncryption")]
    public VirtualNetworkEncryptionModel? RemoteVirtualNetworkEncryption { get; set; }

    [JsonPropertyName("resourceGuid")]
    public string? ResourceGuid { get; set; }

    [JsonPropertyName("useRemoteGateways")]
    public bool? UseRemoteGateways { get; set; }
}
