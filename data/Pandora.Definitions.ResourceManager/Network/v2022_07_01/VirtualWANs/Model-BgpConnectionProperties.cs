using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.VirtualWANs;


internal class BgpConnectionPropertiesModel
{
    [JsonPropertyName("connectionState")]
    public HubBgpConnectionStatusConstant? ConnectionState { get; set; }

    [JsonPropertyName("hubVirtualNetworkConnection")]
    public SubResourceModel? HubVirtualNetworkConnection { get; set; }

    [JsonPropertyName("peerAsn")]
    public int? PeerAsn { get; set; }

    [JsonPropertyName("peerIp")]
    public string? PeerIP { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }
}
