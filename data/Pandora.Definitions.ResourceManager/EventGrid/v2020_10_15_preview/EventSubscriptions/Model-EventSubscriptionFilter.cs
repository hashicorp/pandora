using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.EventSubscriptions
{

    internal class EventSubscriptionFilterModel
    {
        [JsonPropertyName("advancedFilters")]
        public List<AdvancedFilterModel>? AdvancedFilters { get; set; }

        [JsonPropertyName("enableAdvancedFilteringOnArrays")]
        public bool? EnableAdvancedFilteringOnArrays { get; set; }

        [JsonPropertyName("includedEventTypes")]
        public List<string>? IncludedEventTypes { get; set; }

        [JsonPropertyName("isSubjectCaseSensitive")]
        public bool? IsSubjectCaseSensitive { get; set; }

        [JsonPropertyName("subjectBeginsWith")]
        public string? SubjectBeginsWith { get; set; }

        [JsonPropertyName("subjectEndsWith")]
        public string? SubjectEndsWith { get; set; }
    }
}
