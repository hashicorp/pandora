using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_05_01.ReplicationJobs;


internal class JobQueryParameterModel
{
    [JsonPropertyName("affectedObjectTypes")]
    public string? AffectedObjectTypes { get; set; }

    [JsonPropertyName("endTime")]
    public string? EndTime { get; set; }

    [JsonPropertyName("fabricId")]
    public string? FabricId { get; set; }

    [JsonPropertyName("jobName")]
    public string? JobName { get; set; }

    [JsonPropertyName("jobOutputType")]
    public ExportJobOutputSerializationTypeConstant? JobOutputType { get; set; }

    [JsonPropertyName("jobStatus")]
    public string? JobStatus { get; set; }

    [JsonPropertyName("startTime")]
    public string? StartTime { get; set; }

    [JsonPropertyName("timezoneOffset")]
    public float? TimezoneOffset { get; set; }
}
