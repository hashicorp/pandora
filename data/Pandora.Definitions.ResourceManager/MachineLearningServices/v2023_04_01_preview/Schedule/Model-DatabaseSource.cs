using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.Schedule;

[ValueForType("database")]
internal class DatabaseSourceModel : DataImportSourceModel
{
    [JsonPropertyName("query")]
    public string? Query { get; set; }

    [JsonPropertyName("storedProcedure")]
    public string? StoredProcedure { get; set; }

    [JsonPropertyName("storedProcedureParams")]
    public List<Dictionary<string, string>>? StoredProcedureParams { get; set; }

    [JsonPropertyName("tableName")]
    public string? TableName { get; set; }
}
