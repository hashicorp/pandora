// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class SectionGroupModel
{
    [JsonPropertyName("createdBy")]
    public IdentitySetModel? CreatedBy { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastModifiedBy")]
    public IdentitySetModel? LastModifiedBy { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("parentNotebook")]
    public NotebookModel? ParentNotebook { get; set; }

    [JsonPropertyName("parentSectionGroup")]
    public SectionGroupModel? ParentSectionGroup { get; set; }

    [JsonPropertyName("sectionGroups")]
    public List<SectionGroupModel>? SectionGroups { get; set; }

    [JsonPropertyName("sectionGroupsUrl")]
    public string? SectionGroupsUrl { get; set; }

    [JsonPropertyName("sections")]
    public List<OnenoteSectionModel>? Sections { get; set; }

    [JsonPropertyName("sectionsUrl")]
    public string? SectionsUrl { get; set; }

    [JsonPropertyName("self")]
    public string? Self { get; set; }
}
