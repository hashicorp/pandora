using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2022_07_01.Encodings;


internal class FadeModel
{
    [JsonPropertyName("duration")]
    [Required]
    public string Duration { get; set; }

    [JsonPropertyName("fadeColor")]
    [Required]
    public string FadeColor { get; set; }

    [JsonPropertyName("start")]
    public string? Start { get; set; }
}
