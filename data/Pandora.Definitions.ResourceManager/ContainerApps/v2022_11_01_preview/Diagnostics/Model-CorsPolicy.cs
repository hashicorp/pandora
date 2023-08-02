using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_11_01_preview.Diagnostics;


internal class CorsPolicyModel
{
    [JsonPropertyName("allowCredentials")]
    public bool? AllowCredentials { get; set; }

    [JsonPropertyName("allowedHeaders")]
    public List<string>? AllowedHeaders { get; set; }

    [JsonPropertyName("allowedMethods")]
    public List<string>? AllowedMethods { get; set; }

    [JsonPropertyName("allowedOrigins")]
    [Required]
    public List<string> AllowedOrigins { get; set; }

    [JsonPropertyName("exposeHeaders")]
    public List<string>? ExposeHeaders { get; set; }

    [JsonPropertyName("maxAge")]
    public int? MaxAge { get; set; }
}
