using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ContainerAppsAuthConfigs;


internal class LoginModel
{
    [JsonPropertyName("allowedExternalRedirectUrls")]
    public List<string>? AllowedExternalRedirectUrls { get; set; }

    [JsonPropertyName("cookieExpiration")]
    public CookieExpirationModel? CookieExpiration { get; set; }

    [JsonPropertyName("nonce")]
    public NonceModel? Nonce { get; set; }

    [JsonPropertyName("preserveUrlFragmentsForLogins")]
    public bool? PreserveUrlFragmentsForLogins { get; set; }

    [JsonPropertyName("routes")]
    public LoginRoutesModel? Routes { get; set; }
}
