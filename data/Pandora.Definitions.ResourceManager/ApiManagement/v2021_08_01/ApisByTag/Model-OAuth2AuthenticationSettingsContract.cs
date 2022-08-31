using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.ApisByTag;


internal class OAuth2AuthenticationSettingsContractModel
{
    [JsonPropertyName("authorizationServerId")]
    public string? AuthorizationServerId { get; set; }

    [JsonPropertyName("scope")]
    public string? Scope { get; set; }
}
