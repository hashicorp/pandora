using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2021_08_01.ScheduledQueryRules;


internal class ConditionFailingPeriodsModel
{
    [JsonPropertyName("minFailingPeriodsToAlert")]
    public int? MinFailingPeriodsToAlert { get; set; }

    [JsonPropertyName("numberOfEvaluationPeriods")]
    public int? NumberOfEvaluationPeriods { get; set; }
}
