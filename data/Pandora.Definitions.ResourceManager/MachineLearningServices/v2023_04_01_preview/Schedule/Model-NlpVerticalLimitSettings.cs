using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.Schedule;


internal class NlpVerticalLimitSettingsModel
{
    [JsonPropertyName("maxConcurrentTrials")]
    public int? MaxConcurrentTrials { get; set; }

    [JsonPropertyName("maxNodes")]
    public int? MaxNodes { get; set; }

    [JsonPropertyName("maxTrials")]
    public int? MaxTrials { get; set; }

    [JsonPropertyName("timeout")]
    public string? Timeout { get; set; }

    [JsonPropertyName("trialTimeout")]
    public string? TrialTimeout { get; set; }
}
