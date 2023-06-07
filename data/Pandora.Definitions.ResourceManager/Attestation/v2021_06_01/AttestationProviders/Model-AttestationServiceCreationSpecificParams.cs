using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Attestation.v2021_06_01.AttestationProviders;


internal class AttestationServiceCreationSpecificParamsModel
{
    [JsonPropertyName("policySigningCertificates")]
    public JsonWebKeySetModel? PolicySigningCertificates { get; set; }

    [JsonPropertyName("publicNetworkAccess")]
    public PublicNetworkAccessTypeConstant? PublicNetworkAccess { get; set; }

    [JsonPropertyName("tpmAttestationAuthentication")]
    public TpmAttestationAuthenticationTypeConstant? TpmAttestationAuthentication { get; set; }
}
