using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Attestation.v2021_06_01.AttestationProviders;


internal class StatusResultModel
{
    [JsonPropertyName("attestUri")]
    public string? AttestUri { get; set; }

    [JsonPropertyName("privateEndpointConnections")]
    public List<PrivateEndpointConnectionModel>? PrivateEndpointConnections { get; set; }

    [JsonPropertyName("publicNetworkAccess")]
    public PublicNetworkAccessTypeConstant? PublicNetworkAccess { get; set; }

    [JsonPropertyName("status")]
    public AttestationServiceStatusConstant? Status { get; set; }

    [JsonPropertyName("tpmAttestationAuthentication")]
    public TpmAttestationAuthenticationTypeConstant? TpmAttestationAuthentication { get; set; }

    [JsonPropertyName("trustModel")]
    public string? TrustModel { get; set; }
}
