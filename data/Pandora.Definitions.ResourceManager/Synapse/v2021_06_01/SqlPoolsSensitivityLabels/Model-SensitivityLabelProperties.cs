using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.SqlPoolsSensitivityLabels;


internal class SensitivityLabelPropertiesModel
{
    [JsonPropertyName("columnName")]
    public string? ColumnName { get; set; }

    [JsonPropertyName("informationType")]
    public string? InformationType { get; set; }

    [JsonPropertyName("informationTypeId")]
    public string? InformationTypeId { get; set; }

    [JsonPropertyName("isDisabled")]
    public bool? IsDisabled { get; set; }

    [JsonPropertyName("labelId")]
    public string? LabelId { get; set; }

    [JsonPropertyName("labelName")]
    public string? LabelName { get; set; }

    [JsonPropertyName("rank")]
    public SensitivityLabelRankConstant? Rank { get; set; }

    [JsonPropertyName("schemaName")]
    public string? SchemaName { get; set; }

    [JsonPropertyName("tableName")]
    public string? TableName { get; set; }
}
