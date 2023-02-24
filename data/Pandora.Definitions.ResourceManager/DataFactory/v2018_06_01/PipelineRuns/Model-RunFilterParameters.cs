using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.PipelineRuns;


internal class RunFilterParametersModel
{
    [JsonPropertyName("continuationToken")]
    public string? ContinuationToken { get; set; }

    [JsonPropertyName("filters")]
    public List<RunQueryFilterModel>? Filters { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastUpdatedAfter")]
    [Required]
    public DateTime LastUpdatedAfter { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastUpdatedBefore")]
    [Required]
    public DateTime LastUpdatedBefore { get; set; }

    [JsonPropertyName("orderBy")]
    public List<RunQueryOrderByModel>? OrderBy { get; set; }
}
