using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2018_03_01.MetricAlerts;

[ValueForType("DynamicThresholdCriterion")]
internal class DynamicMetricCriteriaModel : MultiMetricCriteriaModel
{
    [JsonPropertyName("alertSensitivity")]
    [Required]
    public DynamicThresholdSensitivityConstant AlertSensitivity { get; set; }

    [JsonPropertyName("failingPeriods")]
    [Required]
    public DynamicThresholdFailingPeriodsModel FailingPeriods { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("ignoreDataBefore")]
    public DateTime? IgnoreDataBefore { get; set; }

    [JsonPropertyName("operator")]
    [Required]
    public DynamicThresholdOperatorConstant Operator { get; set; }
}
