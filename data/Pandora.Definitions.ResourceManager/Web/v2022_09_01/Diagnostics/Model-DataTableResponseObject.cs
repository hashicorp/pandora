using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.Diagnostics;


internal class DataTableResponseObjectModel
{
    [JsonPropertyName("columns")]
    public List<DataTableResponseColumnModel>? Columns { get; set; }

    [JsonPropertyName("rows")]
    public List<List<string>>? Rows { get; set; }

    [JsonPropertyName("tableName")]
    public string? TableName { get; set; }
}
