using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.Schedule;

[ValueForType("TextClassificationMultilabel")]
internal class TextClassificationMultilabelModel : AutoMLVerticalModel
{
    [JsonPropertyName("featurizationSettings")]
    public FeaturizationSettingsModel? FeaturizationSettings { get; set; }

    [JsonPropertyName("limitSettings")]
    public NlpVerticalLimitSettingsModel? LimitSettings { get; set; }

    [JsonPropertyName("primaryMetric")]
    public ClassificationMultilabelPrimaryMetricsConstant? PrimaryMetric { get; set; }

    [JsonPropertyName("validationData")]
    public MLTableJobInputModel? ValidationData { get; set; }
}
