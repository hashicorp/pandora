using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2023_10_01.Metrics;


internal class TimeSeriesElementModel
{
    [JsonPropertyName("data")]
    public List<MetricValueModel>? Data { get; set; }

    [JsonPropertyName("metadatavalues")]
    public List<MetadataValueModel>? Metadatavalues { get; set; }
}
