// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AppCredentialSignInActivityModel
{
    [JsonPropertyName("appId")]
    public string? AppId { get; set; }

    [JsonPropertyName("appObjectId")]
    public string? AppObjectId { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("credentialOrigin")]
    public AppCredentialSignInActivityCredentialOriginConstant? CredentialOrigin { get; set; }

    [JsonPropertyName("expirationDateTime")]
    public DateTime? ExpirationDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("keyId")]
    public string? KeyId { get; set; }

    [JsonPropertyName("keyType")]
    public AppCredentialSignInActivityKeyTypeConstant? KeyType { get; set; }

    [JsonPropertyName("keyUsage")]
    public AppCredentialSignInActivityKeyUsageConstant? KeyUsage { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("resourceId")]
    public string? ResourceId { get; set; }

    [JsonPropertyName("servicePrincipalObjectId")]
    public string? ServicePrincipalObjectId { get; set; }

    [JsonPropertyName("signInActivity")]
    public SignInActivityModel? SignInActivity { get; set; }
}
