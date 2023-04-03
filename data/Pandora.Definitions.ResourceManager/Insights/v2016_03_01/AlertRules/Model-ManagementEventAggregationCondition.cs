using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2016_03_01.AlertRules;


internal class ManagementEventAggregationConditionModel
{
    [JsonPropertyName("operator")]
    public ConditionOperatorConstant? Operator { get; set; }

    [JsonPropertyName("threshold")]
    public float? Threshold { get; set; }

    [JsonPropertyName("windowSize")]
    public string? WindowSize { get; set; }
}
