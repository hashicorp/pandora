using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AppPlatform.v2023_07_01_preview.AppPlatform;

[ValueForType("BasicAuth")]
internal class ContainerRegistryBasicCredentialsModel : ContainerRegistryCredentialsModel
{
    [JsonPropertyName("password")]
    [Required]
    public string Password { get; set; }

    [JsonPropertyName("server")]
    [Required]
    public string Server { get; set; }

    [JsonPropertyName("username")]
    [Required]
    public string Username { get; set; }
}
