// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CryptographySuiteModel
{
    [JsonPropertyName("authenticationTransformConstants")]
    public AuthenticationTransformConstantConstant? AuthenticationTransformConstants { get; set; }

    [JsonPropertyName("cipherTransformConstants")]
    public VpnEncryptionAlgorithmTypeConstant? CipherTransformConstants { get; set; }

    [JsonPropertyName("dhGroup")]
    public DiffieHellmanGroupConstant? DhGroup { get; set; }

    [JsonPropertyName("encryptionMethod")]
    public VpnEncryptionAlgorithmTypeConstant? EncryptionMethod { get; set; }

    [JsonPropertyName("integrityCheckMethod")]
    public VpnIntegrityAlgorithmTypeConstant? IntegrityCheckMethod { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("pfsGroup")]
    public PerfectForwardSecrecyGroupConstant? PfsGroup { get; set; }
}
