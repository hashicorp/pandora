using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.Job;


internal class RegressionTrainingSettingsModel
{
    [JsonPropertyName("allowedTrainingAlgorithms")]
    public List<RegressionModelsConstant>? AllowedTrainingAlgorithms { get; set; }

    [JsonPropertyName("blockedTrainingAlgorithms")]
    public List<RegressionModelsConstant>? BlockedTrainingAlgorithms { get; set; }

    [JsonPropertyName("enableDnnTraining")]
    public bool? EnableDnnTraining { get; set; }

    [JsonPropertyName("enableModelExplainability")]
    public bool? EnableModelExplainability { get; set; }

    [JsonPropertyName("enableOnnxCompatibleModels")]
    public bool? EnableOnnxCompatibleModels { get; set; }

    [JsonPropertyName("enableStackEnsemble")]
    public bool? EnableStackEnsemble { get; set; }

    [JsonPropertyName("enableVoteEnsemble")]
    public bool? EnableVoteEnsemble { get; set; }

    [JsonPropertyName("ensembleModelDownloadTimeout")]
    public string? EnsembleModelDownloadTimeout { get; set; }

    [JsonPropertyName("stackEnsembleSettings")]
    public StackEnsembleSettingsModel? StackEnsembleSettings { get; set; }
}
