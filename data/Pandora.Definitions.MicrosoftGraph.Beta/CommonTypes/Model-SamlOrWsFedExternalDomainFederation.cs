// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SamlOrWsFedExternalDomainFederationModel
{
    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("domains")]
    public List<ExternalDomainNameModel>? Domains { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("issuerUri")]
    public string? IssuerUri { get; set; }

    [JsonPropertyName("metadataExchangeUri")]
    public string? MetadataExchangeUri { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("passiveSignInUri")]
    public string? PassiveSignInUri { get; set; }

    [JsonPropertyName("preferredAuthenticationProtocol")]
    public SamlOrWsFedExternalDomainFederationPreferredAuthenticationProtocolConstant? PreferredAuthenticationProtocol { get; set; }

    [JsonPropertyName("signingCertificate")]
    public string? SigningCertificate { get; set; }
}
