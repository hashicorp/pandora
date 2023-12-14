// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class TermStoreTermModel
{
    [JsonPropertyName("children")]
    public List<TermStoreTermModel>? Children { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("descriptions")]
    public List<TermStoreLocalizedDescriptionModel>? Descriptions { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("labels")]
    public List<TermStoreLocalizedLabelModel>? Labels { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("properties")]
    public List<KeyValueModel>? Properties { get; set; }

    [JsonPropertyName("relations")]
    public List<TermStoreRelationModel>? Relations { get; set; }

    [JsonPropertyName("set")]
    public TermStoreSetModel? Set { get; set; }
}
