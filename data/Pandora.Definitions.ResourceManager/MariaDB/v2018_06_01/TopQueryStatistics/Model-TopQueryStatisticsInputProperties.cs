using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MariaDB.v2018_06_01.TopQueryStatistics;


internal class TopQueryStatisticsInputPropertiesModel
{
    [JsonPropertyName("aggregationFunction")]
    [Required]
    public string AggregationFunction { get; set; }

    [JsonPropertyName("aggregationWindow")]
    [Required]
    public string AggregationWindow { get; set; }

    [JsonPropertyName("numberOfTopQueries")]
    [Required]
    public int NumberOfTopQueries { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("observationEndTime")]
    [Required]
    public DateTime ObservationEndTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("observationStartTime")]
    [Required]
    public DateTime ObservationStartTime { get; set; }

    [JsonPropertyName("observedMetric")]
    [Required]
    public string ObservedMetric { get; set; }
}
