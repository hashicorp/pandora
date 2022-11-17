using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.Job;


internal class ImageModelDistributionSettingsClassificationModel
{
    [JsonPropertyName("amsGradient")]
    public string? AmsGradient { get; set; }

    [JsonPropertyName("augmentations")]
    public string? Augmentations { get; set; }

    [JsonPropertyName("beta1")]
    public string? Beta1 { get; set; }

    [JsonPropertyName("beta2")]
    public string? Beta2 { get; set; }

    [JsonPropertyName("distributed")]
    public string? Distributed { get; set; }

    [JsonPropertyName("earlyStopping")]
    public string? EarlyStopping { get; set; }

    [JsonPropertyName("earlyStoppingDelay")]
    public string? EarlyStoppingDelay { get; set; }

    [JsonPropertyName("earlyStoppingPatience")]
    public string? EarlyStoppingPatience { get; set; }

    [JsonPropertyName("enableOnnxNormalization")]
    public string? EnableOnnxNormalization { get; set; }

    [JsonPropertyName("evaluationFrequency")]
    public string? EvaluationFrequency { get; set; }

    [JsonPropertyName("gradientAccumulationStep")]
    public string? GradientAccumulationStep { get; set; }

    [JsonPropertyName("layersToFreeze")]
    public string? LayersToFreeze { get; set; }

    [JsonPropertyName("learningRate")]
    public string? LearningRate { get; set; }

    [JsonPropertyName("learningRateScheduler")]
    public string? LearningRateScheduler { get; set; }

    [JsonPropertyName("modelName")]
    public string? ModelName { get; set; }

    [JsonPropertyName("momentum")]
    public string? Momentum { get; set; }

    [JsonPropertyName("nesterov")]
    public string? Nesterov { get; set; }

    [JsonPropertyName("numberOfEpochs")]
    public string? NumberOfEpochs { get; set; }

    [JsonPropertyName("numberOfWorkers")]
    public string? NumberOfWorkers { get; set; }

    [JsonPropertyName("optimizer")]
    public string? Optimizer { get; set; }

    [JsonPropertyName("randomSeed")]
    public string? RandomSeed { get; set; }

    [JsonPropertyName("stepLRGamma")]
    public string? StepLRGamma { get; set; }

    [JsonPropertyName("stepLRStepSize")]
    public string? StepLRStepSize { get; set; }

    [JsonPropertyName("trainingBatchSize")]
    public string? TrainingBatchSize { get; set; }

    [JsonPropertyName("trainingCropSize")]
    public string? TrainingCropSize { get; set; }

    [JsonPropertyName("validationBatchSize")]
    public string? ValidationBatchSize { get; set; }

    [JsonPropertyName("validationCropSize")]
    public string? ValidationCropSize { get; set; }

    [JsonPropertyName("validationResizeSize")]
    public string? ValidationResizeSize { get; set; }

    [JsonPropertyName("warmupCosineLRCycles")]
    public string? WarmupCosineLRCycles { get; set; }

    [JsonPropertyName("warmupCosineLRWarmupEpochs")]
    public string? WarmupCosineLRWarmupEpochs { get; set; }

    [JsonPropertyName("weightDecay")]
    public string? WeightDecay { get; set; }

    [JsonPropertyName("weightedLoss")]
    public string? WeightedLoss { get; set; }
}
