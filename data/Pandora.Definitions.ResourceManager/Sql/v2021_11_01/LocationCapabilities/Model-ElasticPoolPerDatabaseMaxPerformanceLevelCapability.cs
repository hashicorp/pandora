using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.LocationCapabilities;


internal class ElasticPoolPerDatabaseMaxPerformanceLevelCapabilityModel
{
    [JsonPropertyName("limit")]
    public float? Limit { get; set; }

    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    [JsonPropertyName("status")]
    public CapabilityStatusConstant? Status { get; set; }

    [JsonPropertyName("supportedPerDatabaseMinPerformanceLevels")]
    public List<ElasticPoolPerDatabaseMinPerformanceLevelCapabilityModel>? SupportedPerDatabaseMinPerformanceLevels { get; set; }

    [JsonPropertyName("unit")]
    public PerformanceLevelUnitConstant? Unit { get; set; }
}
