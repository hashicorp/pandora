using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_07_01_preview.EntityQueries;


internal class ActivityEntityQueryTemplatePropertiesModel
{
    [JsonPropertyName("content")]
    public string? Content { get; set; }

    [JsonPropertyName("dataTypes")]
    public List<DataTypeDefinitionsModel>? DataTypes { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("entitiesFilter")]
    public Dictionary<string, List<string>>? EntitiesFilter { get; set; }

    [JsonPropertyName("inputEntityType")]
    public EntityTypeConstant? InputEntityType { get; set; }

    [JsonPropertyName("queryDefinitions")]
    public ActivityEntityQueryTemplatePropertiesQueryDefinitionsModel? QueryDefinitions { get; set; }

    [JsonPropertyName("requiredInputFieldsSets")]
    public List<List<string>>? RequiredInputFieldsSets { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }
}
