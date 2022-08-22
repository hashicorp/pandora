using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.AuthorizationServer;


internal class AuthorizationServerSecretsContractModel
{
    [JsonPropertyName("clientSecret")]
    public string? ClientSecret { get; set; }

    [JsonPropertyName("resourceOwnerPassword")]
    public string? ResourceOwnerPassword { get; set; }

    [JsonPropertyName("resourceOwnerUsername")]
    public string? ResourceOwnerUsername { get; set; }
}
