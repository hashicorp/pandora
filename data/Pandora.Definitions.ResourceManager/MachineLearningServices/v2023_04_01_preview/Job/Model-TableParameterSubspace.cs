using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.Job;


internal class TableParameterSubspaceModel
{
    [JsonPropertyName("booster")]
    public string? Booster { get; set; }

    [JsonPropertyName("boostingType")]
    public string? BoostingType { get; set; }

    [JsonPropertyName("growPolicy")]
    public string? GrowPolicy { get; set; }

    [JsonPropertyName("learningRate")]
    public string? LearningRate { get; set; }

    [JsonPropertyName("maxBin")]
    public string? MaxBin { get; set; }

    [JsonPropertyName("maxDepth")]
    public string? MaxDepth { get; set; }

    [JsonPropertyName("maxLeaves")]
    public string? MaxLeaves { get; set; }

    [JsonPropertyName("minDataInLeaf")]
    public string? MinDataInLeaf { get; set; }

    [JsonPropertyName("minSplitGain")]
    public string? MinSplitGain { get; set; }

    [JsonPropertyName("modelName")]
    public string? ModelName { get; set; }

    [JsonPropertyName("nEstimators")]
    public string? NEstimators { get; set; }

    [JsonPropertyName("numLeaves")]
    public string? NumLeaves { get; set; }

    [JsonPropertyName("preprocessorName")]
    public string? PreprocessorName { get; set; }

    [JsonPropertyName("regAlpha")]
    public string? RegAlpha { get; set; }

    [JsonPropertyName("regLambda")]
    public string? RegLambda { get; set; }

    [JsonPropertyName("subsample")]
    public string? Subsample { get; set; }

    [JsonPropertyName("subsampleFreq")]
    public string? SubsampleFreq { get; set; }

    [JsonPropertyName("treeMethod")]
    public string? TreeMethod { get; set; }

    [JsonPropertyName("withMean")]
    public string? WithMean { get; set; }

    [JsonPropertyName("withStd")]
    public string? WithStd { get; set; }
}
