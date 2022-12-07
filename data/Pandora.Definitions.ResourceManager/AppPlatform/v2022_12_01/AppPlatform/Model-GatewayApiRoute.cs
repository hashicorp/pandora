using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AppPlatform.v2022_12_01.AppPlatform;


internal class GatewayApiRouteModel
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("filters")]
    public List<string>? Filters { get; set; }

    [JsonPropertyName("order")]
    public int? Order { get; set; }

    [JsonPropertyName("predicates")]
    public List<string>? Predicates { get; set; }

    [JsonPropertyName("ssoEnabled")]
    public bool? SsoEnabled { get; set; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("tokenRelay")]
    public bool? TokenRelay { get; set; }

    [JsonPropertyName("uri")]
    public string? Uri { get; set; }
}
