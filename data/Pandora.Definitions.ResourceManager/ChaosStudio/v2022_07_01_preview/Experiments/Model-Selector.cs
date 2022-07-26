using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ChaosStudio.v2022_07_01_preview.Experiments;


internal class SelectorModel
{
    [JsonPropertyName("id")]
    [Required]
    public string Id { get; set; }

    [MinItems(1)]
    [JsonPropertyName("targets")]
    [Required]
    public List<TargetReferenceModel> Targets { get; set; }

    [JsonPropertyName("type")]
    [Required]
    public SelectorTypeConstant Type { get; set; }
}
