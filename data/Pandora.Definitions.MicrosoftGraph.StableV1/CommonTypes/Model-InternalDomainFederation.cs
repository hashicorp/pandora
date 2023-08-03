// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class InternalDomainFederationModel
{
    [JsonPropertyName("activeSignInUri")]
    public string? ActiveSignInUri { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("federatedIdpMfaBehavior")]
    public FederatedIdpMfaBehaviorConstant? FederatedIdpMfaBehavior { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isSignedAuthenticationRequestRequired")]
    public bool? IsSignedAuthenticationRequestRequired { get; set; }

    [JsonPropertyName("issuerUri")]
    public string? IssuerUri { get; set; }

    [JsonPropertyName("metadataExchangeUri")]
    public string? MetadataExchangeUri { get; set; }

    [JsonPropertyName("nextSigningCertificate")]
    public string? NextSigningCertificate { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("passiveSignInUri")]
    public string? PassiveSignInUri { get; set; }

    [JsonPropertyName("preferredAuthenticationProtocol")]
    public AuthenticationProtocolConstant? PreferredAuthenticationProtocol { get; set; }

    [JsonPropertyName("promptLoginBehavior")]
    public PromptLoginBehaviorConstant? PromptLoginBehavior { get; set; }

    [JsonPropertyName("signOutUri")]
    public string? SignOutUri { get; set; }

    [JsonPropertyName("signingCertificate")]
    public string? SigningCertificate { get; set; }

    [JsonPropertyName("signingCertificateUpdateStatus")]
    public SigningCertificateUpdateStatusModel? SigningCertificateUpdateStatus { get; set; }
}
