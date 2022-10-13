using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AppPlatform.v2022_09_01_preview.AppPlatform;


internal class GitPatternRepositoryModel
{
    [JsonPropertyName("hostKey")]
    public string? HostKey { get; set; }

    [JsonPropertyName("hostKeyAlgorithm")]
    public string? HostKeyAlgorithm { get; set; }

    [JsonPropertyName("label")]
    public string? Label { get; set; }

    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }

    [JsonPropertyName("password")]
    public string? Password { get; set; }

    [JsonPropertyName("pattern")]
    public List<string>? Pattern { get; set; }

    [JsonPropertyName("privateKey")]
    public string? PrivateKey { get; set; }

    [JsonPropertyName("searchPaths")]
    public List<string>? SearchPaths { get; set; }

    [JsonPropertyName("strictHostKeyChecking")]
    public bool? StrictHostKeyChecking { get; set; }

    [JsonPropertyName("uri")]
    [Required]
    public string Uri { get; set; }

    [JsonPropertyName("username")]
    public string? Username { get; set; }
}
