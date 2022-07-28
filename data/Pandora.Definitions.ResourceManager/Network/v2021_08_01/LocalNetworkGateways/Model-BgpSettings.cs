using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.LocalNetworkGateways;


internal class BgpSettingsModel
{
    [JsonPropertyName("asn")]
    public int? Asn { get; set; }

    [JsonPropertyName("bgpPeeringAddress")]
    public string? BgpPeeringAddress { get; set; }

    [JsonPropertyName("bgpPeeringAddresses")]
    public List<IPConfigurationBgpPeeringAddressModel>? BgpPeeringAddresses { get; set; }

    [JsonPropertyName("peerWeight")]
    public int? PeerWeight { get; set; }
}
