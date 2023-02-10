using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_11_15.CosmosDB;


internal class MetricValueModel
{
    [JsonPropertyName("average")]
    public float? Average { get; set; }

    [JsonPropertyName("_count")]
    public float? Count { get; set; }

    [JsonPropertyName("maximum")]
    public float? Maximum { get; set; }

    [JsonPropertyName("minimum")]
    public float? Minimum { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("timestamp")]
    public DateTime? Timestamp { get; set; }

    [JsonPropertyName("total")]
    public float? Total { get; set; }
}
