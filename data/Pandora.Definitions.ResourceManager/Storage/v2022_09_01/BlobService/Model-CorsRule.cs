using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Storage.v2022_09_01.BlobService;


internal class CorsRuleModel
{
    [JsonPropertyName("allowedHeaders")]
    [Required]
    public List<string> AllowedHeaders { get; set; }

    [JsonPropertyName("allowedMethods")]
    [Required]
    public List<AllowedMethodsConstant> AllowedMethods { get; set; }

    [JsonPropertyName("allowedOrigins")]
    [Required]
    public List<string> AllowedOrigins { get; set; }

    [JsonPropertyName("exposedHeaders")]
    [Required]
    public List<string> ExposedHeaders { get; set; }

    [JsonPropertyName("maxAgeInSeconds")]
    [Required]
    public int MaxAgeInSeconds { get; set; }
}
