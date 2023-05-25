using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.ManagedDatabaseQueries;


internal class QueryMetricPropertiesModel
{
    [JsonPropertyName("avg")]
    public float? Avg { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("max")]
    public float? Max { get; set; }

    [JsonPropertyName("min")]
    public float? Min { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("stdev")]
    public float? Stdev { get; set; }

    [JsonPropertyName("sum")]
    public float? Sum { get; set; }

    [JsonPropertyName("unit")]
    public QueryMetricUnitTypeConstant? Unit { get; set; }

    [JsonPropertyName("value")]
    public float? Value { get; set; }
}
