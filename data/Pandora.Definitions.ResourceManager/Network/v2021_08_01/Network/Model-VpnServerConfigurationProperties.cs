using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.Network;


internal class VpnServerConfigurationPropertiesModel
{
    [JsonPropertyName("aadAuthenticationParameters")]
    public AadAuthenticationParametersModel? AadAuthenticationParameters { get; set; }

    [JsonPropertyName("configurationPolicyGroups")]
    public List<VpnServerConfigurationPolicyGroupModel>? ConfigurationPolicyGroups { get; set; }

    [JsonPropertyName("etag")]
    public string? Etag { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("p2SVpnGateways")]
    public List<P2SVpnGatewayModel>? P2SVpnGateways { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("radiusClientRootCertificates")]
    public List<VpnServerConfigRadiusClientRootCertificateModel>? RadiusClientRootCertificates { get; set; }

    [JsonPropertyName("radiusServerAddress")]
    public string? RadiusServerAddress { get; set; }

    [JsonPropertyName("radiusServerRootCertificates")]
    public List<VpnServerConfigRadiusServerRootCertificateModel>? RadiusServerRootCertificates { get; set; }

    [JsonPropertyName("radiusServerSecret")]
    public string? RadiusServerSecret { get; set; }

    [JsonPropertyName("radiusServers")]
    public List<RadiusServerModel>? RadiusServers { get; set; }

    [JsonPropertyName("vpnAuthenticationTypes")]
    public List<VpnAuthenticationTypeConstant>? VpnAuthenticationTypes { get; set; }

    [JsonPropertyName("vpnClientIpsecPolicies")]
    public List<IPsecPolicyModel>? VpnClientIPsecPolicies { get; set; }

    [JsonPropertyName("vpnClientRevokedCertificates")]
    public List<VpnServerConfigVpnClientRevokedCertificateModel>? VpnClientRevokedCertificates { get; set; }

    [JsonPropertyName("vpnClientRootCertificates")]
    public List<VpnServerConfigVpnClientRootCertificateModel>? VpnClientRootCertificates { get; set; }

    [JsonPropertyName("vpnProtocols")]
    public List<VpnGatewayTunnelingProtocolConstant>? VpnProtocols { get; set; }
}
