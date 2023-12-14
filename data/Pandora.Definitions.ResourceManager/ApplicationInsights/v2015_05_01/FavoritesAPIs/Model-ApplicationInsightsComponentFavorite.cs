using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2015_05_01.FavoritesAPIs;


internal class ApplicationInsightsComponentFavoriteModel
{
    [JsonPropertyName("Category")]
    public string? Category { get; set; }

    [JsonPropertyName("Config")]
    public string? Config { get; set; }

    [JsonPropertyName("FavoriteId")]
    public string? FavoriteId { get; set; }

    [JsonPropertyName("FavoriteType")]
    public FavoriteTypeConstant? FavoriteType { get; set; }

    [JsonPropertyName("IsGeneratedFromTemplate")]
    public bool? IsGeneratedFromTemplate { get; set; }

    [JsonPropertyName("Name")]
    public string? Name { get; set; }

    [JsonPropertyName("SourceType")]
    public string? SourceType { get; set; }

    [JsonPropertyName("Tags")]
    public List<string>? Tags { get; set; }

    [JsonPropertyName("TimeModified")]
    public string? TimeModified { get; set; }

    [JsonPropertyName("UserId")]
    public string? UserId { get; set; }

    [JsonPropertyName("Version")]
    public string? Version { get; set; }
}
