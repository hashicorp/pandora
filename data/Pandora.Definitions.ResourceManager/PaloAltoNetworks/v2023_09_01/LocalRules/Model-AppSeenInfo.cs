using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2023_09_01.LocalRules;


internal class AppSeenInfoModel
{
    [JsonPropertyName("category")]
    [Required]
    public string Category { get; set; }

    [JsonPropertyName("risk")]
    [Required]
    public string Risk { get; set; }

    [JsonPropertyName("standardPorts")]
    [Required]
    public string StandardPorts { get; set; }

    [JsonPropertyName("subCategory")]
    [Required]
    public string SubCategory { get; set; }

    [JsonPropertyName("tag")]
    [Required]
    public string Tag { get; set; }

    [JsonPropertyName("technology")]
    [Required]
    public string Technology { get; set; }

    [JsonPropertyName("title")]
    [Required]
    public string Title { get; set; }
}
