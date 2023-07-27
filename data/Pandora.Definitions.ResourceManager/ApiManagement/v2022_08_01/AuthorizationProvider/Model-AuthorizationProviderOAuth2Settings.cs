using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.AuthorizationProvider;


internal class AuthorizationProviderOAuth2SettingsModel
{
    [JsonPropertyName("grantTypes")]
    public AuthorizationProviderOAuth2GrantTypesModel? GrantTypes { get; set; }

    [JsonPropertyName("redirectUrl")]
    public string? RedirectUrl { get; set; }
}
