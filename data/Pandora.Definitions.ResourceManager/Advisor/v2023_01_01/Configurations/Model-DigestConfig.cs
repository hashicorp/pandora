using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Advisor.v2023_01_01.Configurations;


internal class DigestConfigModel
{
    [JsonPropertyName("actionGroupResourceId")]
    public string? ActionGroupResourceId { get; set; }

    [JsonPropertyName("categories")]
    public List<CategoryConstant>? Categories { get; set; }

    [JsonPropertyName("frequency")]
    public int? Frequency { get; set; }

    [JsonPropertyName("language")]
    public string? Language { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("state")]
    public DigestConfigStateConstant? State { get; set; }
}
