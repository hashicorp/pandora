using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2022_10_01.Tables;


internal class SchemaModel
{
    [JsonPropertyName("categories")]
    public List<string>? Categories { get; set; }

    [JsonPropertyName("columns")]
    public List<ColumnModel>? Columns { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("labels")]
    public List<string>? Labels { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("solutions")]
    public List<string>? Solutions { get; set; }

    [JsonPropertyName("source")]
    public SourceEnumConstant? Source { get; set; }

    [JsonPropertyName("standardColumns")]
    public List<ColumnModel>? StandardColumns { get; set; }

    [JsonPropertyName("tableSubType")]
    public TableSubTypeEnumConstant? TableSubType { get; set; }

    [JsonPropertyName("tableType")]
    public TableTypeEnumConstant? TableType { get; set; }
}
