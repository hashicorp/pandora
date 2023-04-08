using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2019_01_01_preview.Automations;

[ValueForType("EventHub")]
internal class AutomationActionEventHubModel : AutomationActionModel
{
    [JsonPropertyName("connectionString")]
    public string? ConnectionString { get; set; }

    [JsonPropertyName("eventHubResourceId")]
    public string? EventHubResourceId { get; set; }

    [JsonPropertyName("sasPolicyName")]
    public string? SasPolicyName { get; set; }
}
