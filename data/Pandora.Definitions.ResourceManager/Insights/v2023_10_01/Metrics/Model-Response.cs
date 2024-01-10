using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2023_10_01.Metrics;


internal class ResponseModel
{
    [JsonPropertyName("cost")]
    public float? Cost { get; set; }

    [JsonPropertyName("interval")]
    public string? Interval { get; set; }

    [JsonPropertyName("namespace")]
    public string? Namespace { get; set; }

    [JsonPropertyName("resourceregion")]
    public string? Resourceregion { get; set; }

    [JsonPropertyName("timespan")]
    [Required]
    public string Timespan { get; set; }

    [JsonPropertyName("value")]
    [Required]
    public List<MetricModel> Value { get; set; }
}
