using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2023_11_01.ContentPackages;


internal class PackageBasePropertiesModel
{
    [JsonPropertyName("author")]
    public MetadataAuthorModel? Author { get; set; }

    [JsonPropertyName("categories")]
    public MetadataCategoriesModel? Categories { get; set; }

    [JsonPropertyName("contentId")]
    public string? ContentId { get; set; }

    [JsonPropertyName("contentKind")]
    public PackageKindConstant? ContentKind { get; set; }

    [JsonPropertyName("contentProductId")]
    public string? ContentProductId { get; set; }

    [JsonPropertyName("contentSchemaVersion")]
    public string? ContentSchemaVersion { get; set; }

    [JsonPropertyName("dependencies")]
    public MetadataDependenciesModel? Dependencies { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("firstPublishDate")]
    public string? FirstPublishDate { get; set; }

    [JsonPropertyName("icon")]
    public string? Icon { get; set; }

    [JsonPropertyName("isDeprecated")]
    public FlagConstant? IsDeprecated { get; set; }

    [JsonPropertyName("isFeatured")]
    public FlagConstant? IsFeatured { get; set; }

    [JsonPropertyName("isNew")]
    public FlagConstant? IsNew { get; set; }

    [JsonPropertyName("isPreview")]
    public FlagConstant? IsPreview { get; set; }

    [JsonPropertyName("lastPublishDate")]
    public string? LastPublishDate { get; set; }

    [JsonPropertyName("providers")]
    public List<string>? Providers { get; set; }

    [JsonPropertyName("publisherDisplayName")]
    public string? PublisherDisplayName { get; set; }

    [JsonPropertyName("source")]
    public MetadataSourceModel? Source { get; set; }

    [JsonPropertyName("support")]
    public MetadataSupportModel? Support { get; set; }

    [JsonPropertyName("threatAnalysisTactics")]
    public List<string>? ThreatAnalysisTactics { get; set; }

    [JsonPropertyName("threatAnalysisTechniques")]
    public List<string>? ThreatAnalysisTechniques { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
