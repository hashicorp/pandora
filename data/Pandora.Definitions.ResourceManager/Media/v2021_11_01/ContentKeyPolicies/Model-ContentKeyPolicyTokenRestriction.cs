using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2021_11_01.ContentKeyPolicies;

[ValueForType("#Microsoft.Media.ContentKeyPolicyTokenRestriction")]
internal class ContentKeyPolicyTokenRestrictionModel : ContentKeyPolicyRestrictionModel
{
    [JsonPropertyName("alternateVerificationKeys")]
    public List<ContentKeyPolicyRestrictionTokenKeyModel>? AlternateVerificationKeys { get; set; }

    [JsonPropertyName("audience")]
    [Required]
    public string Audience { get; set; }

    [JsonPropertyName("issuer")]
    [Required]
    public string Issuer { get; set; }

    [JsonPropertyName("openIdConnectDiscoveryDocument")]
    public string? OpenIdConnectDiscoveryDocument { get; set; }

    [JsonPropertyName("primaryVerificationKey")]
    [Required]
    public ContentKeyPolicyRestrictionTokenKeyModel PrimaryVerificationKey { get; set; }

    [JsonPropertyName("requiredClaims")]
    public List<ContentKeyPolicyTokenClaimModel>? RequiredClaims { get; set; }

    [JsonPropertyName("restrictionTokenType")]
    [Required]
    public ContentKeyPolicyRestrictionTokenTypeConstant RestrictionTokenType { get; set; }
}
