using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AppPlatform.v2022_12_01.AppPlatform;


internal class CustomContainerModel
{
    [JsonPropertyName("args")]
    public List<string>? Args { get; set; }

    [JsonPropertyName("command")]
    public List<string>? Command { get; set; }

    [JsonPropertyName("containerImage")]
    public string? ContainerImage { get; set; }

    [JsonPropertyName("imageRegistryCredential")]
    public ImageRegistryCredentialModel? ImageRegistryCredential { get; set; }

    [JsonPropertyName("languageFramework")]
    public string? LanguageFramework { get; set; }

    [JsonPropertyName("server")]
    public string? Server { get; set; }
}
