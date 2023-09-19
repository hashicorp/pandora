// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class TermStoreSetModel
{
    [JsonPropertyName("children")]
    public List<TermStoreTermModel>? Children { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("localizedNames")]
    public List<TermStoreLocalizedNameModel>? LocalizedNames { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("parentGroup")]
    public TermStoreGroupModel? ParentGroup { get; set; }

    [JsonPropertyName("properties")]
    public List<KeyValueModel>? Properties { get; set; }

    [JsonPropertyName("relations")]
    public List<TermStoreRelationModel>? Relations { get; set; }

    [JsonPropertyName("terms")]
    public List<TermStoreTermModel>? Terms { get; set; }
}
