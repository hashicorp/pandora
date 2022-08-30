using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_03_01.ContainerAppsAuthConfigs;


internal class AuthConfigPropertiesModel
{
    [JsonPropertyName("globalValidation")]
    public GlobalValidationModel? GlobalValidation { get; set; }

    [JsonPropertyName("httpSettings")]
    public HTTPSettingsModel? HTTPSettings { get; set; }

    [JsonPropertyName("identityProviders")]
    public IdentityProvidersModel? IdentityProviders { get; set; }

    [JsonPropertyName("login")]
    public LoginModel? Login { get; set; }

    [JsonPropertyName("platform")]
    public AuthPlatformModel? Platform { get; set; }
}
