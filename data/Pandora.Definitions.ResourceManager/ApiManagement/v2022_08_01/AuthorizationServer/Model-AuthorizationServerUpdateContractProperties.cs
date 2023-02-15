using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.AuthorizationServer;


internal class AuthorizationServerUpdateContractPropertiesModel
{
    [JsonPropertyName("authorizationEndpoint")]
    public string? AuthorizationEndpoint { get; set; }

    [JsonPropertyName("authorizationMethods")]
    public List<AuthorizationMethodConstant>? AuthorizationMethods { get; set; }

    [JsonPropertyName("bearerTokenSendingMethods")]
    public List<BearerTokenSendingMethodConstant>? BearerTokenSendingMethods { get; set; }

    [JsonPropertyName("clientAuthenticationMethod")]
    public List<ClientAuthenticationMethodConstant>? ClientAuthenticationMethod { get; set; }

    [JsonPropertyName("clientId")]
    public string? ClientId { get; set; }

    [JsonPropertyName("clientRegistrationEndpoint")]
    public string? ClientRegistrationEndpoint { get; set; }

    [JsonPropertyName("clientSecret")]
    public string? ClientSecret { get; set; }

    [JsonPropertyName("defaultScope")]
    public string? DefaultScope { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("grantTypes")]
    public List<GrantTypeConstant>? GrantTypes { get; set; }

    [JsonPropertyName("resourceOwnerPassword")]
    public string? ResourceOwnerPassword { get; set; }

    [JsonPropertyName("resourceOwnerUsername")]
    public string? ResourceOwnerUsername { get; set; }

    [JsonPropertyName("supportState")]
    public bool? SupportState { get; set; }

    [JsonPropertyName("tokenBodyParameters")]
    public List<TokenBodyParameterContractModel>? TokenBodyParameters { get; set; }

    [JsonPropertyName("tokenEndpoint")]
    public string? TokenEndpoint { get; set; }

    [JsonPropertyName("useInApiDocumentation")]
    public bool? UseInApiDocumentation { get; set; }

    [JsonPropertyName("useInTestConsole")]
    public bool? UseInTestConsole { get; set; }
}
