using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ContainerAppsAuthConfigs;


internal class AuthConfigPropertiesModel
{
    [JsonPropertyName("globalValidation")]
    public GlobalValidationModel? GlobalValidation { get; set; }

    [JsonPropertyName("httpSettings")]
    public HttpSettingsModel? HttpSettings { get; set; }

    [JsonPropertyName("identityProviders")]
    public IdentityProvidersModel? IdentityProviders { get; set; }

    [JsonPropertyName("login")]
    public LoginModel? Login { get; set; }

    [JsonPropertyName("platform")]
    public AuthPlatformModel? Platform { get; set; }
}
