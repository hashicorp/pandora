using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.Schedule;


internal class NlpFixedParametersModel
{
    [JsonPropertyName("gradientAccumulationSteps")]
    public int? GradientAccumulationSteps { get; set; }

    [JsonPropertyName("learningRate")]
    public float? LearningRate { get; set; }

    [JsonPropertyName("learningRateScheduler")]
    public NlpLearningRateSchedulerConstant? LearningRateScheduler { get; set; }

    [JsonPropertyName("modelName")]
    public string? ModelName { get; set; }

    [JsonPropertyName("numberOfEpochs")]
    public int? NumberOfEpochs { get; set; }

    [JsonPropertyName("trainingBatchSize")]
    public int? TrainingBatchSize { get; set; }

    [JsonPropertyName("validationBatchSize")]
    public int? ValidationBatchSize { get; set; }

    [JsonPropertyName("warmupRatio")]
    public float? WarmupRatio { get; set; }

    [JsonPropertyName("weightDecay")]
    public float? WeightDecay { get; set; }
}
