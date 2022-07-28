using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.VirtualNetworkGatewayConnections;


internal class VpnClientConfigurationModel
{
    [JsonPropertyName("aadAudience")]
    public string? AadAudience { get; set; }

    [JsonPropertyName("aadIssuer")]
    public string? AadIssuer { get; set; }

    [JsonPropertyName("aadTenant")]
    public string? AadTenant { get; set; }

    [JsonPropertyName("radiusServerAddress")]
    public string? RadiusServerAddress { get; set; }

    [JsonPropertyName("radiusServerSecret")]
    public string? RadiusServerSecret { get; set; }

    [JsonPropertyName("radiusServers")]
    public List<RadiusServerModel>? RadiusServers { get; set; }

    [JsonPropertyName("vpnAuthenticationTypes")]
    public List<VpnAuthenticationTypeConstant>? VpnAuthenticationTypes { get; set; }

    [JsonPropertyName("vpnClientAddressPool")]
    public AddressSpaceModel? VpnClientAddressPool { get; set; }

    [JsonPropertyName("vpnClientIpsecPolicies")]
    public List<IPsecPolicyModel>? VpnClientIPsecPolicies { get; set; }

    [JsonPropertyName("vpnClientProtocols")]
    public List<VpnClientProtocolConstant>? VpnClientProtocols { get; set; }

    [JsonPropertyName("vpnClientRevokedCertificates")]
    public List<VpnClientRevokedCertificateModel>? VpnClientRevokedCertificates { get; set; }

    [JsonPropertyName("vpnClientRootCertificates")]
    public List<VpnClientRootCertificateModel>? VpnClientRootCertificates { get; set; }
}
