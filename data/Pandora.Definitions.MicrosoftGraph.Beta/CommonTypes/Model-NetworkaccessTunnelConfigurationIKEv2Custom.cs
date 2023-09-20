// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class NetworkaccessTunnelConfigurationIKEv2CustomModel
{
    [JsonPropertyName("dhGroup")]
    public NetworkaccessTunnelConfigurationIKEv2CustomDhGroupConstant? DhGroup { get; set; }

    [JsonPropertyName("ikeEncryption")]
    public NetworkaccessTunnelConfigurationIKEv2CustomIkeEncryptionConstant? IkeEncryption { get; set; }

    [JsonPropertyName("ikeIntegrity")]
    public NetworkaccessTunnelConfigurationIKEv2CustomIkeIntegrityConstant? IkeIntegrity { get; set; }

    [JsonPropertyName("ipSecEncryption")]
    public NetworkaccessTunnelConfigurationIKEv2CustomIpSecEncryptionConstant? IpSecEncryption { get; set; }

    [JsonPropertyName("ipSecIntegrity")]
    public NetworkaccessTunnelConfigurationIKEv2CustomIpSecIntegrityConstant? IpSecIntegrity { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("pfsGroup")]
    public NetworkaccessTunnelConfigurationIKEv2CustomPfsGroupConstant? PfsGroup { get; set; }

    [JsonPropertyName("preSharedKey")]
    public string? PreSharedKey { get; set; }

    [JsonPropertyName("saLifeTimeSeconds")]
    public int? SaLifeTimeSeconds { get; set; }
}
