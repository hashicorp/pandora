using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_09_10.ReplicationJobs;

[ValueForType("AutomationRunbookTaskDetails")]
internal class AutomationRunbookTaskDetailsModel : TaskTypeDetailsModel
{
    [JsonPropertyName("accountName")]
    public string? AccountName { get; set; }

    [JsonPropertyName("cloudServiceName")]
    public string? CloudServiceName { get; set; }

    [JsonPropertyName("isPrimarySideScript")]
    public bool? IsPrimarySideScript { get; set; }

    [JsonPropertyName("jobId")]
    public string? JobId { get; set; }

    [JsonPropertyName("jobOutput")]
    public string? JobOutput { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("runbookId")]
    public string? RunbookId { get; set; }

    [JsonPropertyName("runbookName")]
    public string? RunbookName { get; set; }

    [JsonPropertyName("subscriptionId")]
    public string? SubscriptionId { get; set; }
}
