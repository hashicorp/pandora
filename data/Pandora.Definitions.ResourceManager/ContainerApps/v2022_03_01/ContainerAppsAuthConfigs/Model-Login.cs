using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_03_01.ContainerAppsAuthConfigs;


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
