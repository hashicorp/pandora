using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.Schedule;

[ValueForType("Categorical")]
internal class CategoricalPredictionDriftMetricThresholdModel : PredictionDriftMetricThresholdBaseModel
{
    [JsonPropertyName("metric")]
    [Required]
    public CategoricalPredictionDriftMetricConstant Metric { get; set; }
}
