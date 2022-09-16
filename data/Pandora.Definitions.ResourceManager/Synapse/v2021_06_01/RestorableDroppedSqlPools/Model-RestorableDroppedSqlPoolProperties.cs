using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.RestorableDroppedSqlPools;


internal class RestorableDroppedSqlPoolPropertiesModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("creationDate")]
    public DateTime? CreationDate { get; set; }

    [JsonPropertyName("databaseName")]
    public string? DatabaseName { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("deletionDate")]
    public DateTime? DeletionDate { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("earliestRestoreDate")]
    public DateTime? EarliestRestoreDate { get; set; }

    [JsonPropertyName("edition")]
    public string? Edition { get; set; }

    [JsonPropertyName("elasticPoolName")]
    public string? ElasticPoolName { get; set; }

    [JsonPropertyName("maxSizeBytes")]
    public string? MaxSizeBytes { get; set; }

    [JsonPropertyName("serviceLevelObjective")]
    public string? ServiceLevelObjective { get; set; }
}
