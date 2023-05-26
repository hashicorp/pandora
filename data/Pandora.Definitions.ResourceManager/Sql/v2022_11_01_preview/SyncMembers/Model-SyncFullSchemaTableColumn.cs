using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.SyncMembers;


internal class SyncFullSchemaTableColumnModel
{
    [JsonPropertyName("dataSize")]
    public string? DataSize { get; set; }

    [JsonPropertyName("dataType")]
    public string? DataType { get; set; }

    [JsonPropertyName("errorId")]
    public string? ErrorId { get; set; }

    [JsonPropertyName("hasError")]
    public bool? HasError { get; set; }

    [JsonPropertyName("isPrimaryKey")]
    public bool? IsPrimaryKey { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("quotedName")]
    public string? QuotedName { get; set; }
}
