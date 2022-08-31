using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Dynatrace.v2021_09_01.Monitors;


internal class SSODetailsResponseModel
{
    [JsonPropertyName("aadDomains")]
    public List<string>? AadDomains { get; set; }

    [JsonPropertyName("adminUsers")]
    public List<string>? AdminUsers { get; set; }

    [JsonPropertyName("isSsoEnabled")]
    public SSOStatusConstant? IsSsoEnabled { get; set; }

    [JsonPropertyName("metadataUrl")]
    public string? MetadataUrl { get; set; }

    [JsonPropertyName("singleSignOnUrl")]
    public string? SingleSignOnUrl { get; set; }
}
