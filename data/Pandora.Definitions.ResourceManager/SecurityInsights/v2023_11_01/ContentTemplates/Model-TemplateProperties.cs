using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2023_11_01.ContentTemplates;


internal class TemplatePropertiesModel
{
    [JsonPropertyName("author")]
    public MetadataAuthorModel? Author { get; set; }

    [JsonPropertyName("categories")]
    public MetadataCategoriesModel? Categories { get; set; }

    [JsonPropertyName("contentId")]
    [Required]
    public string ContentId { get; set; }

    [JsonPropertyName("contentKind")]
    [Required]
    public KindConstant ContentKind { get; set; }

    [JsonPropertyName("contentProductId")]
    [Required]
    public string ContentProductId { get; set; }

    [JsonPropertyName("contentSchemaVersion")]
    public string? ContentSchemaVersion { get; set; }

    [JsonPropertyName("customVersion")]
    public string? CustomVersion { get; set; }

    [JsonPropertyName("dependantTemplates")]
    public List<TemplatePropertiesModel>? DependantTemplates { get; set; }

    [JsonPropertyName("dependencies")]
    public MetadataDependenciesModel? Dependencies { get; set; }

    [JsonPropertyName("displayName")]
    [Required]
    public string DisplayName { get; set; }

    [JsonPropertyName("firstPublishDate")]
    public string? FirstPublishDate { get; set; }

    [JsonPropertyName("icon")]
    public string? Icon { get; set; }

    [JsonPropertyName("isDeprecated")]
    public FlagConstant? IsDeprecated { get; set; }

    [JsonPropertyName("lastPublishDate")]
    public string? LastPublishDate { get; set; }

    [JsonPropertyName("mainTemplate")]
    public object? MainTemplate { get; set; }

    [JsonPropertyName("packageId")]
    [Required]
    public string PackageId { get; set; }

    [JsonPropertyName("packageKind")]
    public PackageKindConstant? PackageKind { get; set; }

    [JsonPropertyName("packageName")]
    public string? PackageName { get; set; }

    [JsonPropertyName("packageVersion")]
    [Required]
    public string PackageVersion { get; set; }

    [JsonPropertyName("previewImages")]
    public List<string>? PreviewImages { get; set; }

    [JsonPropertyName("previewImagesDark")]
    public List<string>? PreviewImagesDark { get; set; }

    [JsonPropertyName("providers")]
    public List<string>? Providers { get; set; }

    [JsonPropertyName("source")]
    [Required]
    public MetadataSourceModel Source { get; set; }

    [JsonPropertyName("support")]
    public MetadataSupportModel? Support { get; set; }

    [JsonPropertyName("threatAnalysisTactics")]
    public List<string>? ThreatAnalysisTactics { get; set; }

    [JsonPropertyName("threatAnalysisTechniques")]
    public List<string>? ThreatAnalysisTechniques { get; set; }

    [JsonPropertyName("version")]
    [Required]
    public string Version { get; set; }
}
