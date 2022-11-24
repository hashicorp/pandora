using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationEvents;

[ValueForType("JobStatus")]
internal class JobStatusEventDetailsModel : EventSpecificDetailsModel
{
    [JsonPropertyName("affectedObjectType")]
    public string? AffectedObjectType { get; set; }

    [JsonPropertyName("jobFriendlyName")]
    public string? JobFriendlyName { get; set; }

    [JsonPropertyName("jobId")]
    public string? JobId { get; set; }

    [JsonPropertyName("jobStatus")]
    public string? JobStatus { get; set; }
}
