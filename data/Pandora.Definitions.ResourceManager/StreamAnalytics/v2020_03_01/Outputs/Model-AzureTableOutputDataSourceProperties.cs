using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StreamAnalytics.v2020_03_01.Outputs;


internal class AzureTableOutputDataSourcePropertiesModel
{
    [JsonPropertyName("accountKey")]
    public string? AccountKey { get; set; }

    [JsonPropertyName("accountName")]
    public string? AccountName { get; set; }

    [JsonPropertyName("batchSize")]
    public int? BatchSize { get; set; }

    [JsonPropertyName("columnsToRemove")]
    public List<string>? ColumnsToRemove { get; set; }

    [JsonPropertyName("partitionKey")]
    public string? PartitionKey { get; set; }

    [JsonPropertyName("rowKey")]
    public string? RowKey { get; set; }

    [JsonPropertyName("table")]
    public string? Table { get; set; }
}
