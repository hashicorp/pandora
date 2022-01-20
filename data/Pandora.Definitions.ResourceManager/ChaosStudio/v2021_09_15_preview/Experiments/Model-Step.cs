using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ChaosStudio.v2021_09_15_preview.Experiments;


internal class StepModel
{
    [MinItems(1)]
    [JsonPropertyName("branches")]
    [Required]
    public List<BranchModel> Branches { get; set; }

    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }
}
