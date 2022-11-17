using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.Job;


internal class TableVerticalLimitSettingsModel
{
    [JsonPropertyName("enableEarlyTermination")]
    public bool? EnableEarlyTermination { get; set; }

    [JsonPropertyName("exitScore")]
    public float? ExitScore { get; set; }

    [JsonPropertyName("maxConcurrentTrials")]
    public int? MaxConcurrentTrials { get; set; }

    [JsonPropertyName("maxCoresPerTrial")]
    public int? MaxCoresPerTrial { get; set; }

    [JsonPropertyName("maxTrials")]
    public int? MaxTrials { get; set; }

    [JsonPropertyName("timeout")]
    public string? Timeout { get; set; }

    [JsonPropertyName("trialTimeout")]
    public string? TrialTimeout { get; set; }
}
