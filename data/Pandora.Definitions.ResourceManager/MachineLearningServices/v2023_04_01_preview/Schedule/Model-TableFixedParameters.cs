using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.Schedule;


internal class TableFixedParametersModel
{
    [JsonPropertyName("booster")]
    public string? Booster { get; set; }

    [JsonPropertyName("boostingType")]
    public string? BoostingType { get; set; }

    [JsonPropertyName("growPolicy")]
    public string? GrowPolicy { get; set; }

    [JsonPropertyName("learningRate")]
    public float? LearningRate { get; set; }

    [JsonPropertyName("maxBin")]
    public int? MaxBin { get; set; }

    [JsonPropertyName("maxDepth")]
    public int? MaxDepth { get; set; }

    [JsonPropertyName("maxLeaves")]
    public int? MaxLeaves { get; set; }

    [JsonPropertyName("minDataInLeaf")]
    public int? MinDataInLeaf { get; set; }

    [JsonPropertyName("minSplitGain")]
    public float? MinSplitGain { get; set; }

    [JsonPropertyName("modelName")]
    public string? ModelName { get; set; }

    [JsonPropertyName("nEstimators")]
    public int? NEstimators { get; set; }

    [JsonPropertyName("numLeaves")]
    public int? NumLeaves { get; set; }

    [JsonPropertyName("preprocessorName")]
    public string? PreprocessorName { get; set; }

    [JsonPropertyName("regAlpha")]
    public float? RegAlpha { get; set; }

    [JsonPropertyName("regLambda")]
    public float? RegLambda { get; set; }

    [JsonPropertyName("subsample")]
    public float? Subsample { get; set; }

    [JsonPropertyName("subsampleFreq")]
    public float? SubsampleFreq { get; set; }

    [JsonPropertyName("treeMethod")]
    public string? TreeMethod { get; set; }

    [JsonPropertyName("withMean")]
    public bool? WithMean { get; set; }

    [JsonPropertyName("withStd")]
    public bool? WithStd { get; set; }
}
