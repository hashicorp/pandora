using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataShare.v2019_11_01.DataSet;


internal class SqlDWTablePropertiesModel
{
    [JsonPropertyName("dataSetId")]
    public string? DataSetId { get; set; }

    [JsonPropertyName("dataWarehouseName")]
    [Required]
    public string DataWarehouseName { get; set; }

    [JsonPropertyName("schemaName")]
    [Required]
    public string SchemaName { get; set; }

    [JsonPropertyName("sqlServerResourceId")]
    [Required]
    public string SqlServerResourceId { get; set; }

    [JsonPropertyName("tableName")]
    [Required]
    public string TableName { get; set; }
}
