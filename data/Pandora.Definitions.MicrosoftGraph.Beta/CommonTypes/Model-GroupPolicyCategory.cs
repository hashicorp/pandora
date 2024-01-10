// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class GroupPolicyCategoryModel
{
    [JsonPropertyName("children")]
    public List<GroupPolicyCategoryModel>? Children { get; set; }

    [JsonPropertyName("definitionFile")]
    public GroupPolicyDefinitionFileModel? DefinitionFile { get; set; }

    [JsonPropertyName("definitions")]
    public List<GroupPolicyDefinitionModel>? Definitions { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("ingestionSource")]
    public GroupPolicyCategoryIngestionSourceConstant? IngestionSource { get; set; }

    [JsonPropertyName("isRoot")]
    public bool? IsRoot { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("parent")]
    public GroupPolicyCategoryModel? Parent { get; set; }
}
