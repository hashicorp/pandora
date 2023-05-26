using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.Schedule;

[ValueForType("Sweep")]
internal class SweepJobModel : JobBaseModel
{
    [JsonPropertyName("earlyTermination")]
    public EarlyTerminationPolicyModel? EarlyTermination { get; set; }

    [JsonPropertyName("inputs")]
    public Dictionary<string, JobInputModel>? Inputs { get; set; }

    [JsonPropertyName("limits")]
    public JobLimitsModel? Limits { get; set; }

    [JsonPropertyName("objective")]
    [Required]
    public ObjectiveModel Objective { get; set; }

    [JsonPropertyName("outputs")]
    public Dictionary<string, JobOutputModel>? Outputs { get; set; }

    [JsonPropertyName("samplingAlgorithm")]
    [Required]
    public SamplingAlgorithmModel SamplingAlgorithm { get; set; }

    [JsonPropertyName("searchSpace")]
    [Required]
    public object SearchSpace { get; set; }

    [JsonPropertyName("trial")]
    [Required]
    public TrialComponentModel Trial { get; set; }
}
