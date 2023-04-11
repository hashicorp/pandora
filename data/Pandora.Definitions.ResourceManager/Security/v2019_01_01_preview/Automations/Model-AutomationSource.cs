using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2019_01_01_preview.Automations;


internal class AutomationSourceModel
{
    [JsonPropertyName("eventSource")]
    public EventSourceConstant? EventSource { get; set; }

    [JsonPropertyName("ruleSets")]
    public List<AutomationRuleSetModel>? RuleSets { get; set; }
}
