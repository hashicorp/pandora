using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2021_09_01_preview.EntityQueries;


internal class ActivityEntityQueriesPropertiesModel
{
    [JsonPropertyName("content")]
    public string? Content { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdTimeUtc")]
    public DateTime? CreatedTimeUtc { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    [JsonPropertyName("entitiesFilter")]
    public Dictionary<string, List<string>>? EntitiesFilter { get; set; }

    [JsonPropertyName("inputEntityType")]
    public EntityTypeConstant? InputEntityType { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastModifiedTimeUtc")]
    public DateTime? LastModifiedTimeUtc { get; set; }

    [JsonPropertyName("queryDefinitions")]
    public ActivityEntityQueriesPropertiesQueryDefinitionsModel? QueryDefinitions { get; set; }

    [JsonPropertyName("requiredInputFieldsSets")]
    public List<List<string>>? RequiredInputFieldsSets { get; set; }

    [JsonPropertyName("templateName")]
    public string? TemplateName { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }
}
