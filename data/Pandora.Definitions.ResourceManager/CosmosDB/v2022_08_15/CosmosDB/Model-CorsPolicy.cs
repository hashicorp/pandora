using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_08_15.CosmosDB;


internal class CorsPolicyModel
{
    [JsonPropertyName("allowedHeaders")]
    public string? AllowedHeaders { get; set; }

    [JsonPropertyName("allowedMethods")]
    public string? AllowedMethods { get; set; }

    [JsonPropertyName("allowedOrigins")]
    [Required]
    public string AllowedOrigins { get; set; }

    [JsonPropertyName("exposedHeaders")]
    public string? ExposedHeaders { get; set; }

    [JsonPropertyName("maxAgeInSeconds")]
    public int? MaxAgeInSeconds { get; set; }
}
