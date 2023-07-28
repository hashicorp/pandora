using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.Schedule;


internal class NlpParameterSubspaceModel
{
    [JsonPropertyName("gradientAccumulationSteps")]
    public string? GradientAccumulationSteps { get; set; }

    [JsonPropertyName("learningRate")]
    public string? LearningRate { get; set; }

    [JsonPropertyName("learningRateScheduler")]
    public string? LearningRateScheduler { get; set; }

    [JsonPropertyName("modelName")]
    public string? ModelName { get; set; }

    [JsonPropertyName("numberOfEpochs")]
    public string? NumberOfEpochs { get; set; }

    [JsonPropertyName("trainingBatchSize")]
    public string? TrainingBatchSize { get; set; }

    [JsonPropertyName("validationBatchSize")]
    public string? ValidationBatchSize { get; set; }

    [JsonPropertyName("warmupRatio")]
    public string? WarmupRatio { get; set; }

    [JsonPropertyName("weightDecay")]
    public string? WeightDecay { get; set; }
}
