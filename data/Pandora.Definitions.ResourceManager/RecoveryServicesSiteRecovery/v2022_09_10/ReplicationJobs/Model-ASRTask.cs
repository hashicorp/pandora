using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_09_10.ReplicationJobs;


internal class ASRTaskModel
{
    [JsonPropertyName("allowedActions")]
    public List<string>? AllowedActions { get; set; }

    [JsonPropertyName("customDetails")]
    public TaskTypeDetailsModel? CustomDetails { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("endTime")]
    public DateTime? EndTime { get; set; }

    [JsonPropertyName("errors")]
    public List<JobErrorDetailsModel>? Errors { get; set; }

    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [JsonPropertyName("groupTaskCustomDetails")]
    public GroupTaskDetailsModel? GroupTaskCustomDetails { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startTime")]
    public DateTime? StartTime { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("stateDescription")]
    public string? StateDescription { get; set; }

    [JsonPropertyName("taskId")]
    public string? TaskId { get; set; }

    [JsonPropertyName("taskType")]
    public string? TaskType { get; set; }
}
