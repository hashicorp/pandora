// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CertificateAuthorityAsEntityModel
{
    [JsonPropertyName("certificate")]
    public string? Certificate { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isRootAuthority")]
    public bool? IsRootAuthority { get; set; }

    [JsonPropertyName("issuer")]
    public string? Issuer { get; set; }

    [JsonPropertyName("issuerSubjectKeyIdentifier")]
    public string? IssuerSubjectKeyIdentifier { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
