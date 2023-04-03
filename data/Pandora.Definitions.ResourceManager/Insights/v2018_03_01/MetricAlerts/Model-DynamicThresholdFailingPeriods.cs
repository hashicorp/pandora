using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2018_03_01.MetricAlerts;


internal class DynamicThresholdFailingPeriodsModel
{
    [JsonPropertyName("minFailingPeriodsToAlert")]
    [Required]
    public float MinFailingPeriodsToAlert { get; set; }

    [JsonPropertyName("numberOfEvaluationPeriods")]
    [Required]
    public float NumberOfEvaluationPeriods { get; set; }
}
