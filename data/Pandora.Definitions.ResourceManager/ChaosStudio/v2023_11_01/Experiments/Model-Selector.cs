using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ChaosStudio.v2023_11_01.Experiments;


internal class SelectorModel
{
    [JsonPropertyName("filter")]
    public FilterModel? Filter { get; set; }

    [JsonPropertyName("id")]
    [Required]
    public string Id { get; set; }

    [JsonPropertyName("type")]
    [Required]
    public SelectorTypeConstant Type { get; set; }
}
