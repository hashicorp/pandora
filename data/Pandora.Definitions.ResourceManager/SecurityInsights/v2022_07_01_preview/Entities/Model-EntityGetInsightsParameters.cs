using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_07_01_preview.Entities;


internal class EntityGetInsightsParametersModel
{
    [JsonPropertyName("addDefaultExtendedTimeRange")]
    public bool? AddDefaultExtendedTimeRange { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("endTime")]
    [Required]
    public DateTime EndTime { get; set; }

    [JsonPropertyName("insightQueryIds")]
    public List<string>? InsightQueryIds { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startTime")]
    [Required]
    public DateTime StartTime { get; set; }
}
