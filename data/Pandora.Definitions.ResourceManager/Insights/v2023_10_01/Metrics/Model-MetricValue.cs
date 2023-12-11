using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2023_10_01.Metrics;


internal class MetricValueModel
{
    [JsonPropertyName("average")]
    public float? Average { get; set; }

    [JsonPropertyName("count")]
    public float? Count { get; set; }

    [JsonPropertyName("maximum")]
    public float? Maximum { get; set; }

    [JsonPropertyName("minimum")]
    public float? Minimum { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("timeStamp")]
    [Required]
    public DateTime TimeStamp { get; set; }

    [JsonPropertyName("total")]
    public float? Total { get; set; }
}
