using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2020_08_01.SavedSearches;


internal class SavedSearchPropertiesModel
{
    [JsonPropertyName("category")]
    [Required]
    public string Category { get; set; }

    [JsonPropertyName("displayName")]
    [Required]
    public string DisplayName { get; set; }

    [JsonPropertyName("functionAlias")]
    public string? FunctionAlias { get; set; }

    [JsonPropertyName("functionParameters")]
    public string? FunctionParameters { get; set; }

    [JsonPropertyName("query")]
    [Required]
    public string Query { get; set; }

    [JsonPropertyName("tags")]
    public List<TagModel>? Tags { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }
}
