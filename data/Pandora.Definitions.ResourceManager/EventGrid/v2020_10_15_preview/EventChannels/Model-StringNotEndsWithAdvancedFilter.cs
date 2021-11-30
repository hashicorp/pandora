using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.EventChannels
{
    [ValueForType("StringNotEndsWith")]
    internal class StringNotEndsWithAdvancedFilterModel : AdvancedFilterModel
    {
        [JsonPropertyName("values")]
        public List<string>? Values { get; set; }
    }
}
