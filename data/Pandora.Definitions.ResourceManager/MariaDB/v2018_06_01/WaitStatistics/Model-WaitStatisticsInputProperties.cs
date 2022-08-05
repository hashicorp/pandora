using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MariaDB.v2018_06_01.WaitStatistics;


internal class WaitStatisticsInputPropertiesModel
{
    [JsonPropertyName("aggregationWindow")]
    [Required]
    public string AggregationWindow { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("observationEndTime")]
    [Required]
    public DateTime ObservationEndTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("observationStartTime")]
    [Required]
    public DateTime ObservationStartTime { get; set; }
}
