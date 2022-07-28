using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.P2SVpnGateways;


internal class P2SVpnGatewayPropertiesModel
{
    [JsonPropertyName("customDnsServers")]
    public List<string>? CustomDnsServers { get; set; }

    [JsonPropertyName("isRoutingPreferenceInternet")]
    public bool? IsRoutingPreferenceInternet { get; set; }

    [JsonPropertyName("p2SConnectionConfigurations")]
    public List<P2SConnectionConfigurationModel>? P2SConnectionConfigurations { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("virtualHub")]
    public SubResourceModel? VirtualHub { get; set; }

    [JsonPropertyName("vpnClientConnectionHealth")]
    public VpnClientConnectionHealthModel? VpnClientConnectionHealth { get; set; }

    [JsonPropertyName("vpnGatewayScaleUnit")]
    public int? VpnGatewayScaleUnit { get; set; }

    [JsonPropertyName("vpnServerConfiguration")]
    public SubResourceModel? VpnServerConfiguration { get; set; }
}
