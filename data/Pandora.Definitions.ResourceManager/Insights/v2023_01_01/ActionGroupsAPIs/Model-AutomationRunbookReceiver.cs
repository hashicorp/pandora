using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2023_01_01.ActionGroupsAPIs;


internal class AutomationRunbookReceiverModel
{
    [JsonPropertyName("automationAccountId")]
    [Required]
    public string AutomationAccountId { get; set; }

    [JsonPropertyName("isGlobalRunbook")]
    [Required]
    public bool IsGlobalRunbook { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("runbookName")]
    [Required]
    public string RunbookName { get; set; }

    [JsonPropertyName("serviceUri")]
    public string? ServiceUri { get; set; }

    [JsonPropertyName("useCommonAlertSchema")]
    public bool? UseCommonAlertSchema { get; set; }

    [JsonPropertyName("webhookResourceId")]
    [Required]
    public string WebhookResourceId { get; set; }
}
