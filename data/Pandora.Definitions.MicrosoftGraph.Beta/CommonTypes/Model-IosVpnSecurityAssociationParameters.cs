// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class IosVpnSecurityAssociationParametersModel
{
    [JsonPropertyName("lifetimeInMinutes")]
    public int? LifetimeInMinutes { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("securityDiffieHellmanGroup")]
    public int? SecurityDiffieHellmanGroup { get; set; }

    [JsonPropertyName("securityEncryptionAlgorithm")]
    public IosVpnSecurityAssociationParametersSecurityEncryptionAlgorithmConstant? SecurityEncryptionAlgorithm { get; set; }

    [JsonPropertyName("securityIntegrityAlgorithm")]
    public IosVpnSecurityAssociationParametersSecurityIntegrityAlgorithmConstant? SecurityIntegrityAlgorithm { get; set; }
}
