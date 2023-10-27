using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ChaosStudio.v2023_11_01.Experiments;


internal class StepModel
{
    [MinItems(1)]
    [MaxItems(9)]
    [JsonPropertyName("branches")]
    [Required]
    public List<BranchModel> Branches { get; set; }

    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }
}
