using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.MessagingPlan;


internal class MessagingPlanPropertiesModel
{
    [JsonPropertyName("revision")]
    public int? Revision { get; set; }

    [JsonPropertyName("selectedEventHubUnit")]
    public int? SelectedEventHubUnit { get; set; }

    [JsonPropertyName("sku")]
    public int? Sku { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("updatedAt")]
    public DateTime? UpdatedAt { get; set; }
}
