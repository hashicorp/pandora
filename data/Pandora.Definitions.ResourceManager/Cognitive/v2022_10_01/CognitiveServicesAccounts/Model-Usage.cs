using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Cognitive.v2022_10_01.CognitiveServicesAccounts;


internal class UsageModel
{
    [JsonPropertyName("currentValue")]
    public float? CurrentValue { get; set; }

    [JsonPropertyName("limit")]
    public float? Limit { get; set; }

    [JsonPropertyName("name")]
    public MetricNameModel? Name { get; set; }

    [JsonPropertyName("nextResetTime")]
    public string? NextResetTime { get; set; }

    [JsonPropertyName("quotaPeriod")]
    public string? QuotaPeriod { get; set; }

    [JsonPropertyName("status")]
    public QuotaUsageStatusConstant? Status { get; set; }

    [JsonPropertyName("unit")]
    public UnitTypeConstant? Unit { get; set; }
}
