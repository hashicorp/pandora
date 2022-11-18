using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerInstance.v2022_09_01.ContainerInstance;


internal class ImageRegistryCredentialModel
{
    [JsonPropertyName("identity")]
    public string? Identity { get; set; }

    [JsonPropertyName("identityUrl")]
    public string? IdentityUrl { get; set; }

    [JsonPropertyName("password")]
    public string? Password { get; set; }

    [JsonPropertyName("server")]
    [Required]
    public string Server { get; set; }

    [JsonPropertyName("username")]
    public string? Username { get; set; }
}
