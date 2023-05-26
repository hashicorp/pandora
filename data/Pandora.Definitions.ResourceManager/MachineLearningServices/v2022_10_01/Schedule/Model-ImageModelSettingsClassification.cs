using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.Schedule;


internal class ImageModelSettingsClassificationModel
{
    [JsonPropertyName("advancedSettings")]
    public string? AdvancedSettings { get; set; }

    [JsonPropertyName("amsGradient")]
    public bool? AmsGradient { get; set; }

    [JsonPropertyName("augmentations")]
    public string? Augmentations { get; set; }

    [JsonPropertyName("beta1")]
    public float? Beta1 { get; set; }

    [JsonPropertyName("beta2")]
    public float? Beta2 { get; set; }

    [JsonPropertyName("checkpointFrequency")]
    public int? CheckpointFrequency { get; set; }

    [JsonPropertyName("checkpointModel")]
    public JobInputModel? CheckpointModel { get; set; }

    [JsonPropertyName("checkpointRunId")]
    public string? CheckpointRunId { get; set; }

    [JsonPropertyName("distributed")]
    public bool? Distributed { get; set; }

    [JsonPropertyName("earlyStopping")]
    public bool? EarlyStopping { get; set; }

    [JsonPropertyName("earlyStoppingDelay")]
    public int? EarlyStoppingDelay { get; set; }

    [JsonPropertyName("earlyStoppingPatience")]
    public int? EarlyStoppingPatience { get; set; }

    [JsonPropertyName("enableOnnxNormalization")]
    public bool? EnableOnnxNormalization { get; set; }

    [JsonPropertyName("evaluationFrequency")]
    public int? EvaluationFrequency { get; set; }

    [JsonPropertyName("gradientAccumulationStep")]
    public int? GradientAccumulationStep { get; set; }

    [JsonPropertyName("layersToFreeze")]
    public int? LayersToFreeze { get; set; }

    [JsonPropertyName("learningRate")]
    public float? LearningRate { get; set; }

    [JsonPropertyName("learningRateScheduler")]
    public LearningRateSchedulerConstant? LearningRateScheduler { get; set; }

    [JsonPropertyName("modelName")]
    public string? ModelName { get; set; }

    [JsonPropertyName("momentum")]
    public float? Momentum { get; set; }

    [JsonPropertyName("nesterov")]
    public bool? Nesterov { get; set; }

    [JsonPropertyName("numberOfEpochs")]
    public int? NumberOfEpochs { get; set; }

    [JsonPropertyName("numberOfWorkers")]
    public int? NumberOfWorkers { get; set; }

    [JsonPropertyName("optimizer")]
    public StochasticOptimizerConstant? Optimizer { get; set; }

    [JsonPropertyName("randomSeed")]
    public int? RandomSeed { get; set; }

    [JsonPropertyName("stepLRGamma")]
    public float? StepLRGamma { get; set; }

    [JsonPropertyName("stepLRStepSize")]
    public int? StepLRStepSize { get; set; }

    [JsonPropertyName("trainingBatchSize")]
    public int? TrainingBatchSize { get; set; }

    [JsonPropertyName("trainingCropSize")]
    public int? TrainingCropSize { get; set; }

    [JsonPropertyName("validationBatchSize")]
    public int? ValidationBatchSize { get; set; }

    [JsonPropertyName("validationCropSize")]
    public int? ValidationCropSize { get; set; }

    [JsonPropertyName("validationResizeSize")]
    public int? ValidationResizeSize { get; set; }

    [JsonPropertyName("warmupCosineLRCycles")]
    public float? WarmupCosineLRCycles { get; set; }

    [JsonPropertyName("warmupCosineLRWarmupEpochs")]
    public int? WarmupCosineLRWarmupEpochs { get; set; }

    [JsonPropertyName("weightDecay")]
    public float? WeightDecay { get; set; }

    [JsonPropertyName("weightedLoss")]
    public int? WeightedLoss { get; set; }
}
