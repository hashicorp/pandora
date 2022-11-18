using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.Schedule;


internal class ImageModelDistributionSettingsObjectDetectionModel
{
    [JsonPropertyName("amsGradient")]
    public string? AmsGradient { get; set; }

    [JsonPropertyName("augmentations")]
    public string? Augmentations { get; set; }

    [JsonPropertyName("beta1")]
    public string? Beta1 { get; set; }

    [JsonPropertyName("beta2")]
    public string? Beta2 { get; set; }

    [JsonPropertyName("boxDetectionsPerImage")]
    public string? BoxDetectionsPerImage { get; set; }

    [JsonPropertyName("boxScoreThreshold")]
    public string? BoxScoreThreshold { get; set; }

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

    [JsonPropertyName("imageSize")]
    public string? ImageSize { get; set; }

    [JsonPropertyName("layersToFreeze")]
    public string? LayersToFreeze { get; set; }

    [JsonPropertyName("learningRate")]
    public string? LearningRate { get; set; }

    [JsonPropertyName("learningRateScheduler")]
    public string? LearningRateScheduler { get; set; }

    [JsonPropertyName("maxSize")]
    public string? MaxSize { get; set; }

    [JsonPropertyName("minSize")]
    public string? MinSize { get; set; }

    [JsonPropertyName("modelName")]
    public string? ModelName { get; set; }

    [JsonPropertyName("modelSize")]
    public string? ModelSize { get; set; }

    [JsonPropertyName("momentum")]
    public string? Momentum { get; set; }

    [JsonPropertyName("multiScale")]
    public string? MultiScale { get; set; }

    [JsonPropertyName("nesterov")]
    public string? Nesterov { get; set; }

    [JsonPropertyName("nmsIouThreshold")]
    public string? NmsIouThreshold { get; set; }

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

    [JsonPropertyName("tileGridSize")]
    public string? TileGridSize { get; set; }

    [JsonPropertyName("tileOverlapRatio")]
    public string? TileOverlapRatio { get; set; }

    [JsonPropertyName("tilePredictionsNmsThreshold")]
    public string? TilePredictionsNmsThreshold { get; set; }

    [JsonPropertyName("trainingBatchSize")]
    public string? TrainingBatchSize { get; set; }

    [JsonPropertyName("validationBatchSize")]
    public string? ValidationBatchSize { get; set; }

    [JsonPropertyName("validationIouThreshold")]
    public string? ValidationIouThreshold { get; set; }

    [JsonPropertyName("validationMetricType")]
    public string? ValidationMetricType { get; set; }

    [JsonPropertyName("warmupCosineLRCycles")]
    public string? WarmupCosineLRCycles { get; set; }

    [JsonPropertyName("warmupCosineLRWarmupEpochs")]
    public string? WarmupCosineLRWarmupEpochs { get; set; }

    [JsonPropertyName("weightDecay")]
    public string? WeightDecay { get; set; }
}
