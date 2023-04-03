using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2016_03_01.AlertRulesAPIs;

[ValueForType("Microsoft.Azure.Management.Insights.Models.RuleWebhookAction")]
internal class RuleWebhookActionModel : RuleActionModel
{
    [JsonPropertyName("properties")]
    public Dictionary<string, string>? Properties { get; set; }

    [JsonPropertyName("serviceUri")]
    public string? ServiceUri { get; set; }
}
