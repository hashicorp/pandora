using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.EventChannels
{

    internal class EventChannelFilterModel
    {
        [JsonPropertyName("advancedFilters")]
        public List<AdvancedFilterModel>? AdvancedFilters { get; set; }

        [JsonPropertyName("enableAdvancedFilteringOnArrays")]
        public bool? EnableAdvancedFilteringOnArrays { get; set; }
    }
}
