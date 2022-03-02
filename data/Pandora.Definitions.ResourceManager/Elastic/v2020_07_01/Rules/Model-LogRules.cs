using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Elastic.v2020_07_01.Rules;


internal class LogRulesModel
{
    [JsonPropertyName("filteringTags")]
    public List<FilteringTagModel>? FilteringTags { get; set; }

    [JsonPropertyName("sendAadLogs")]
    public bool? SendAadLogs { get; set; }

    [JsonPropertyName("sendActivityLogs")]
    public bool? SendActivityLogs { get; set; }

    [JsonPropertyName("sendSubscriptionLogs")]
    public bool? SendSubscriptionLogs { get; set; }
}
