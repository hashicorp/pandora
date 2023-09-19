// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SearchBookmarkModel
{
    [JsonPropertyName("availabilityEndDateTime")]
    public DateTime? AvailabilityEndDateTime { get; set; }

    [JsonPropertyName("availabilityStartDateTime")]
    public DateTime? AvailabilityStartDateTime { get; set; }

    [JsonPropertyName("categories")]
    public List<string>? Categories { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("groupIds")]
    public List<string>? GroupIds { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isSuggested")]
    public bool? IsSuggested { get; set; }

    [JsonPropertyName("keywords")]
    public SearchAnswerKeywordModel? Keywords { get; set; }

    [JsonPropertyName("languageTags")]
    public List<string>? LanguageTags { get; set; }

    [JsonPropertyName("lastModifiedBy")]
    public SearchIdentitySetModel? LastModifiedBy { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("platforms")]
    public List<SearchBookmarkPlatformsConstant>? Platforms { get; set; }

    [JsonPropertyName("powerAppIds")]
    public List<string>? PowerAppIds { get; set; }

    [JsonPropertyName("state")]
    public SearchBookmarkStateConstant? State { get; set; }

    [JsonPropertyName("targetedVariations")]
    public List<SearchAnswerVariantModel>? TargetedVariations { get; set; }

    [JsonPropertyName("webUrl")]
    public string? WebUrl { get; set; }
}
