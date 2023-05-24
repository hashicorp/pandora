using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Cognitive.v2023_05_01.Models;


internal class ModelModel
{
    [JsonPropertyName("kind")]
    public string? Kind { get; set; }

    [JsonPropertyName("model")]
    public AccountModelModel? Model { get; set; }

    [JsonPropertyName("skuName")]
    public string? SkuName { get; set; }
}
