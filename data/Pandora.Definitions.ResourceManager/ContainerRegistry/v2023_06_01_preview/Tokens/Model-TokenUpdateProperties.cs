using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2023_06_01_preview.Tokens;


internal class TokenUpdatePropertiesModel
{
    [JsonPropertyName("credentials")]
    public TokenCredentialsPropertiesModel? Credentials { get; set; }

    [JsonPropertyName("scopeMapId")]
    public string? ScopeMapId { get; set; }

    [JsonPropertyName("status")]
    public TokenStatusConstant? Status { get; set; }
}
