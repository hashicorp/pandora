using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_07_01_preview.DataConnectors;


internal class CodelessConnectorPollingAuthPropertiesModel
{
    [JsonPropertyName("apiKeyIdentifier")]
    public string? ApiKeyIdentifier { get; set; }

    [JsonPropertyName("apiKeyName")]
    public string? ApiKeyName { get; set; }

    [JsonPropertyName("authType")]
    [Required]
    public string AuthType { get; set; }

    [JsonPropertyName("authorizationEndpoint")]
    public string? AuthorizationEndpoint { get; set; }

    [JsonPropertyName("authorizationEndpointQueryParameters")]
    public object? AuthorizationEndpointQueryParameters { get; set; }

    [JsonPropertyName("flowName")]
    public string? FlowName { get; set; }

    [JsonPropertyName("isApiKeyInPostPayload")]
    public string? IsApiKeyInPostPayload { get; set; }

    [JsonPropertyName("isClientSecretInHeader")]
    public bool? IsClientSecretInHeader { get; set; }

    [JsonPropertyName("redirectionEndpoint")]
    public string? RedirectionEndpoint { get; set; }

    [JsonPropertyName("scope")]
    public string? Scope { get; set; }

    [JsonPropertyName("tokenEndpoint")]
    public string? TokenEndpoint { get; set; }

    [JsonPropertyName("tokenEndpointHeaders")]
    public object? TokenEndpointHeaders { get; set; }

    [JsonPropertyName("tokenEndpointQueryParameters")]
    public object? TokenEndpointQueryParameters { get; set; }
}
