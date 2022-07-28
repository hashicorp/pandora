using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.VpnGateways;


internal class IPConfigurationBgpPeeringAddressModel
{
    [JsonPropertyName("customBgpIpAddresses")]
    public List<string>? CustomBgpIPAddresses { get; set; }

    [JsonPropertyName("defaultBgpIpAddresses")]
    public List<string>? DefaultBgpIPAddresses { get; set; }

    [JsonPropertyName("ipconfigurationId")]
    public string? IPconfigurationId { get; set; }

    [JsonPropertyName("tunnelIpAddresses")]
    public List<string>? TunnelIPAddresses { get; set; }
}
