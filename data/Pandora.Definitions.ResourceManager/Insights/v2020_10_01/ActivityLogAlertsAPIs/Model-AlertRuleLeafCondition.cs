using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2020_10_01.ActivityLogAlertsAPIs;


internal class AlertRuleLeafConditionModel
{
    [JsonPropertyName("containsAny")]
    public List<string>? ContainsAny { get; set; }

    [JsonPropertyName("equals")]
    public string? Equals { get; set; }

    [JsonPropertyName("field")]
    public string? Field { get; set; }
}
