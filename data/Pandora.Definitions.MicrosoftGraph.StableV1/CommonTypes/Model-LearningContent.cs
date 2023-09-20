// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class LearningContentModel
{
    [JsonPropertyName("additionalTags")]
    public List<string>? AdditionalTags { get; set; }

    [JsonPropertyName("contentWebUrl")]
    public string? ContentWebUrl { get; set; }

    [JsonPropertyName("contributors")]
    public List<string>? Contributors { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("duration")]
    public string? Duration { get; set; }

    [JsonPropertyName("externalId")]
    public string? ExternalId { get; set; }

    [JsonPropertyName("format")]
    public string? Format { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isActive")]
    public bool? IsActive { get; set; }

    [JsonPropertyName("isPremium")]
    public bool? IsPremium { get; set; }

    [JsonPropertyName("isSearchable")]
    public bool? IsSearchable { get; set; }

    [JsonPropertyName("languageTag")]
    public string? LanguageTag { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("numberOfPages")]
    public int? NumberOfPages { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("skillTags")]
    public List<string>? SkillTags { get; set; }

    [JsonPropertyName("sourceName")]
    public string? SourceName { get; set; }

    [JsonPropertyName("thumbnailWebUrl")]
    public string? ThumbnailWebUrl { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }
}
