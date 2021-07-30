using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.PowerBIDedicated.v2021_01_01.AutoScaleVCores
{

    internal class AutoScaleVCoreListResult
    {
        [JsonPropertyName("value")]
        [Required]
        public List<AutoScaleVCore> Value { get; set; }
    }
}
