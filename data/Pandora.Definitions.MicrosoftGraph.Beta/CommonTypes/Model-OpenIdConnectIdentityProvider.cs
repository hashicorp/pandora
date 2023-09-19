// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class OpenIdConnectIdentityProviderModel
{
    [JsonPropertyName("claimsMapping")]
    public ClaimsMappingModel? ClaimsMapping { get; set; }

    [JsonPropertyName("clientId")]
    public string? ClientId { get; set; }

    [JsonPropertyName("clientSecret")]
    public string? ClientSecret { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("domainHint")]
    public string? DomainHint { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("metadataUrl")]
    public string? MetadataUrl { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("responseMode")]
    public OpenIdConnectIdentityProviderResponseModeConstant? ResponseMode { get; set; }

    [JsonPropertyName("responseType")]
    public OpenIdConnectIdentityProviderResponseTypeConstant? ResponseType { get; set; }

    [JsonPropertyName("scope")]
    public string? Scope { get; set; }
}
