using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_09_10.ReplicationMigrationItems;


internal class CriticalJobHistoryDetailsModel
{
    [JsonPropertyName("jobId")]
    public string? JobId { get; set; }

    [JsonPropertyName("jobName")]
    public string? JobName { get; set; }

    [JsonPropertyName("jobStatus")]
    public string? JobStatus { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startTime")]
    public DateTime? StartTime { get; set; }
}
