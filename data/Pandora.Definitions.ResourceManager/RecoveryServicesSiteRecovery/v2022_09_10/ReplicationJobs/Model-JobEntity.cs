using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_09_10.ReplicationJobs;


internal class JobEntityModel
{
    [JsonPropertyName("jobFriendlyName")]
    public string? JobFriendlyName { get; set; }

    [JsonPropertyName("jobId")]
    public string? JobId { get; set; }

    [JsonPropertyName("jobScenarioName")]
    public string? JobScenarioName { get; set; }

    [JsonPropertyName("targetInstanceType")]
    public string? TargetInstanceType { get; set; }

    [JsonPropertyName("targetObjectId")]
    public string? TargetObjectId { get; set; }

    [JsonPropertyName("targetObjectName")]
    public string? TargetObjectName { get; set; }
}
