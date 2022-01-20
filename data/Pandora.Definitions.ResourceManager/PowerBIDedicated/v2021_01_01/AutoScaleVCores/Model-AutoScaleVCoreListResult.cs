using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.PowerBIDedicated.v2021_01_01.AutoScaleVCores;


internal class AutoScaleVCoreListResultModel
{
    [JsonPropertyName("value")]
    [Required]
    public List<AutoScaleVCoreModel> Value { get; set; }
}
