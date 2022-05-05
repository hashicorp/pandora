using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ChaosStudio.v2021_09_15_preview.Experiments;


internal class BranchStatusModel
{
    [JsonPropertyName("actions")]
    public List<ActionStatusModel>? Actions { get; set; }

    [JsonPropertyName("branchId")]
    public string? BranchId { get; set; }

    [JsonPropertyName("branchName")]
    public string? BranchName { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
