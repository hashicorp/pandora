using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2021_09_01_preview.Metadata;


internal class MetadataPropertiesPatchModel
{
    [JsonPropertyName("author")]
    public MetadataAuthorModel? Author { get; set; }

    [JsonPropertyName("categories")]
    public MetadataCategoriesModel? Categories { get; set; }

    [JsonPropertyName("contentId")]
    public string? ContentId { get; set; }

    [JsonPropertyName("dependencies")]
    public MetadataDependenciesModel? Dependencies { get; set; }

    [JsonPropertyName("firstPublishDate")]
    public string? FirstPublishDate { get; set; }

    [JsonPropertyName("kind")]
    public KindConstant? Kind { get; set; }

    [JsonPropertyName("lastPublishDate")]
    public string? LastPublishDate { get; set; }

    [JsonPropertyName("parentId")]
    public string? ParentId { get; set; }

    [JsonPropertyName("providers")]
    public List<string>? Providers { get; set; }

    [JsonPropertyName("source")]
    public MetadataSourceModel? Source { get; set; }

    [JsonPropertyName("support")]
    public MetadataSupportModel? Support { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
