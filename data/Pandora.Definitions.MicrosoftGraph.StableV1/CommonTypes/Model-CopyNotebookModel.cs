// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class CopyNotebookModelModel
{
    [JsonPropertyName("createdBy")]
    public string? CreatedBy { get; set; }

    [JsonPropertyName("createdByIdentity")]
    public IdentitySetModel? CreatedByIdentity { get; set; }

    [JsonPropertyName("createdTime")]
    public DateTime? CreatedTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isDefault")]
    public bool? IsDefault { get; set; }

    [JsonPropertyName("isShared")]
    public bool? IsShared { get; set; }

    [JsonPropertyName("lastModifiedBy")]
    public string? LastModifiedBy { get; set; }

    [JsonPropertyName("lastModifiedByIdentity")]
    public IdentitySetModel? LastModifiedByIdentity { get; set; }

    [JsonPropertyName("lastModifiedTime")]
    public DateTime? LastModifiedTime { get; set; }

    [JsonPropertyName("links")]
    public NotebookLinksModel? Links { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("sectionGroupsUrl")]
    public string? SectionGroupsUrl { get; set; }

    [JsonPropertyName("sectionsUrl")]
    public string? SectionsUrl { get; set; }

    [JsonPropertyName("self")]
    public string? Self { get; set; }

    [JsonPropertyName("userRole")]
    public CopyNotebookModelUserRoleConstant? UserRole { get; set; }
}
