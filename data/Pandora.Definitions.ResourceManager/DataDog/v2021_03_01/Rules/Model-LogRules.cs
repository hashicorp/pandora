using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataDog.v2021_03_01.Rules;


internal class LogRulesModel
{
    [JsonPropertyName("filteringTags")]
    public List<FilteringTagModel>? FilteringTags { get; set; }

    [JsonPropertyName("sendAadLogs")]
    public bool? SendAadLogs { get; set; }

    [JsonPropertyName("sendResourceLogs")]
    public bool? SendResourceLogs { get; set; }

    [JsonPropertyName("sendSubscriptionLogs")]
    public bool? SendSubscriptionLogs { get; set; }
}
