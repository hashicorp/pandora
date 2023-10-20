using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2023_09_01.Firewalls;


internal class NetworkProfileModel
{
    [JsonPropertyName("egressNatIp")]
    public List<IPAddressModel>? EgressNatIP { get; set; }

    [JsonPropertyName("enableEgressNat")]
    [Required]
    public EgressNatConstant EnableEgressNat { get; set; }

    [JsonPropertyName("networkType")]
    [Required]
    public NetworkTypeConstant NetworkType { get; set; }

    [JsonPropertyName("publicIps")]
    [Required]
    public List<IPAddressModel> PublicIPs { get; set; }

    [JsonPropertyName("trustedRanges")]
    public List<string>? TrustedRanges { get; set; }

    [JsonPropertyName("vnetConfiguration")]
    public VnetConfigurationModel? VnetConfiguration { get; set; }

    [JsonPropertyName("vwanConfiguration")]
    public VwanConfigurationModel? VwanConfiguration { get; set; }
}
