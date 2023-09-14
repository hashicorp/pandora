using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Redis.v2023_08_01.Redis;


internal class SkuModel
{
    [JsonPropertyName("capacity")]
    [Required]
    public int Capacity { get; set; }

    [JsonPropertyName("family")]
    [Required]
    public SkuFamilyConstant Family { get; set; }

    [JsonPropertyName("name")]
    [Required]
    public SkuNameConstant Name { get; set; }
}
