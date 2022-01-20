using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ChaosStudio.v2021_09_15_preview.Experiments;


internal class BranchModel
{
    [MinItems(1)]
    [JsonPropertyName("actions")]
    [Required]
    public List<ActionModel> Actions { get; set; }

    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }
}
