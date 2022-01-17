using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ChaosStudio.v2021_09_15_preview.Experiments
{

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
}
