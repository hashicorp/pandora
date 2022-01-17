using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ChaosStudio.v2021_09_15_preview.Experiments
{

    internal class TargetReferenceModel
    {
        [JsonPropertyName("id")]
        [Required]
        public string Id { get; set; }

        [JsonPropertyName("type")]
        [Required]
        public TargetReferenceTypeConstant Type { get; set; }
    }
}
