using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.Authorization;


internal class AuthorizationContractPropertiesModel
{
    [JsonPropertyName("authorizationType")]
    public AuthorizationTypeConstant? AuthorizationType { get; set; }

    [JsonPropertyName("error")]
    public AuthorizationErrorModel? Error { get; set; }

    [JsonPropertyName("oauth2grantType")]
    public OAuth2GrantTypeConstant? Oauth2grantType { get; set; }

    [JsonPropertyName("parameters")]
    public Dictionary<string, string>? Parameters { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
