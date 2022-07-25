using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2021_09_01_preview.Entities;


internal class InsightQueryItemPropertiesModel
{
    [JsonPropertyName("additionalQuery")]
    public InsightQueryItemPropertiesAdditionalQueryModel? AdditionalQuery { get; set; }

    [JsonPropertyName("baseQuery")]
    public string? BaseQuery { get; set; }

    [JsonPropertyName("chartQuery")]
    public object? ChartQuery { get; set; }

    [JsonPropertyName("dataTypes")]
    public List<EntityQueryItemPropertiesDataTypesInlinedModel>? DataTypes { get; set; }

    [JsonPropertyName("defaultTimeRange")]
    public InsightQueryItemPropertiesDefaultTimeRangeModel? DefaultTimeRange { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("entitiesFilter")]
    public object? EntitiesFilter { get; set; }

    [JsonPropertyName("inputEntityType")]
    public EntityTypeConstant? InputEntityType { get; set; }

    [JsonPropertyName("referenceTimeRange")]
    public InsightQueryItemPropertiesReferenceTimeRangeModel? ReferenceTimeRange { get; set; }

    [JsonPropertyName("requiredInputFieldsSets")]
    public List<List<string>>? RequiredInputFieldsSets { get; set; }

    [JsonPropertyName("tableQuery")]
    public InsightQueryItemPropertiesTableQueryModel? TableQuery { get; set; }
}
