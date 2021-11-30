using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.TopicTypes
{

    internal class EventTypesListResultModel
    {
        [JsonPropertyName("value")]
        public List<EventTypeModel>? Value { get; set; }
    }
}
