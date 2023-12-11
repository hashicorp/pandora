using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2023_11_01.BicepClient;


internal class FileDefinitionModel
{
    [JsonPropertyName("contents")]
    public string? Contents { get; set; }

    [JsonPropertyName("path")]
    public string? Path { get; set; }
}
