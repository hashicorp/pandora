using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.WebApps;


internal class SiteAuthSettingsPropertiesModel
{
    [JsonPropertyName("aadClaimsAuthorization")]
    public string? AadClaimsAuthorization { get; set; }

    [JsonPropertyName("additionalLoginParams")]
    public List<string>? AdditionalLoginParams { get; set; }

    [JsonPropertyName("allowedAudiences")]
    public List<string>? AllowedAudiences { get; set; }

    [JsonPropertyName("allowedExternalRedirectUrls")]
    public List<string>? AllowedExternalRedirectUrls { get; set; }

    [JsonPropertyName("authFilePath")]
    public string? AuthFilePath { get; set; }

    [JsonPropertyName("clientId")]
    public string? ClientId { get; set; }

    [JsonPropertyName("clientSecret")]
    public string? ClientSecret { get; set; }

    [JsonPropertyName("clientSecretCertificateThumbprint")]
    public string? ClientSecretCertificateThumbprint { get; set; }

    [JsonPropertyName("clientSecretSettingName")]
    public string? ClientSecretSettingName { get; set; }

    [JsonPropertyName("configVersion")]
    public string? ConfigVersion { get; set; }

    [JsonPropertyName("defaultProvider")]
    public BuiltInAuthenticationProviderConstant? DefaultProvider { get; set; }

    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    [JsonPropertyName("facebookAppId")]
    public string? FacebookAppId { get; set; }

    [JsonPropertyName("facebookAppSecret")]
    public string? FacebookAppSecret { get; set; }

    [JsonPropertyName("facebookAppSecretSettingName")]
    public string? FacebookAppSecretSettingName { get; set; }

    [JsonPropertyName("facebookOAuthScopes")]
    public List<string>? FacebookOAuthScopes { get; set; }

    [JsonPropertyName("gitHubClientId")]
    public string? GitHubClientId { get; set; }

    [JsonPropertyName("gitHubClientSecret")]
    public string? GitHubClientSecret { get; set; }

    [JsonPropertyName("gitHubClientSecretSettingName")]
    public string? GitHubClientSecretSettingName { get; set; }

    [JsonPropertyName("gitHubOAuthScopes")]
    public List<string>? GitHubOAuthScopes { get; set; }

    [JsonPropertyName("googleClientId")]
    public string? GoogleClientId { get; set; }

    [JsonPropertyName("googleClientSecret")]
    public string? GoogleClientSecret { get; set; }

    [JsonPropertyName("googleClientSecretSettingName")]
    public string? GoogleClientSecretSettingName { get; set; }

    [JsonPropertyName("googleOAuthScopes")]
    public List<string>? GoogleOAuthScopes { get; set; }

    [JsonPropertyName("isAuthFromFile")]
    public string? IsAuthFromFile { get; set; }

    [JsonPropertyName("issuer")]
    public string? Issuer { get; set; }

    [JsonPropertyName("microsoftAccountClientId")]
    public string? MicrosoftAccountClientId { get; set; }

    [JsonPropertyName("microsoftAccountClientSecret")]
    public string? MicrosoftAccountClientSecret { get; set; }

    [JsonPropertyName("microsoftAccountClientSecretSettingName")]
    public string? MicrosoftAccountClientSecretSettingName { get; set; }

    [JsonPropertyName("microsoftAccountOAuthScopes")]
    public List<string>? MicrosoftAccountOAuthScopes { get; set; }

    [JsonPropertyName("runtimeVersion")]
    public string? RuntimeVersion { get; set; }

    [JsonPropertyName("tokenRefreshExtensionHours")]
    public float? TokenRefreshExtensionHours { get; set; }

    [JsonPropertyName("tokenStoreEnabled")]
    public bool? TokenStoreEnabled { get; set; }

    [JsonPropertyName("twitterConsumerKey")]
    public string? TwitterConsumerKey { get; set; }

    [JsonPropertyName("twitterConsumerSecret")]
    public string? TwitterConsumerSecret { get; set; }

    [JsonPropertyName("twitterConsumerSecretSettingName")]
    public string? TwitterConsumerSecretSettingName { get; set; }

    [JsonPropertyName("unauthenticatedClientAction")]
    public UnauthenticatedClientActionConstant? UnauthenticatedClientAction { get; set; }

    [JsonPropertyName("validateIssuer")]
    public bool? ValidateIssuer { get; set; }
}
