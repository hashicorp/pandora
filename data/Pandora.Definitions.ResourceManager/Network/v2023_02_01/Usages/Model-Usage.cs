using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_02_01.Usages;


internal class UsageModel
{
    [JsonPropertyName("currentValue")]
    [Required]
    public int CurrentValue { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("limit")]
    [Required]
    public int Limit { get; set; }

    [JsonPropertyName("name")]
    [Required]
    public UsageNameModel Name { get; set; }

    [JsonPropertyName("unit")]
    [Required]
    public UsageUnitConstant Unit { get; set; }
}
