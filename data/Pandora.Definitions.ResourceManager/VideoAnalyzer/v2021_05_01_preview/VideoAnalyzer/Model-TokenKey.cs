using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.VideoAnalyzer.v2021_05_01_preview.VideoAnalyzer;


internal abstract class TokenKeyModel
{
    [JsonPropertyName("kid")]
    [Required]
    public string Kid { get; set; }

    [JsonPropertyName("@type")]
    [ProvidesTypeHint]
    [Required]
    public string Type { get; set; }
}
